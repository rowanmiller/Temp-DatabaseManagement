using System;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Web.Http;
using FakeEstateWeb.Hubs;

namespace FakeEstateWeb.Controllers
{
    public class ManagementApiController : ApiController
    {
        public enum ApplyMigrationResult
        {
            DatabaseUpToDate,
            PendingModelChanges
        }

        public ApplyMigrationResult ApplyMigrations(string migrationsConfiguration)
        {
            var configType = Type.GetType(migrationsConfiguration);
            var config = (DbMigrationsConfiguration)Activator.CreateInstance(configType);
            MigratorBase migrator = new DbMigrator(config);
            migrator = new MigratorLoggingDecorator(migrator, new MigrationLogR(config.ContextType.Name));

            try
            {
                migrator.Update();
                return ApplyMigrationResult.DatabaseUpToDate;
            }
            catch (AutomaticMigrationsDisabledException)
            {
                return ApplyMigrationResult.PendingModelChanges;
            }
        }

        private class MigrationLogR : MigrationsLogger
        {
            private readonly string _context;

            public MigrationLogR(string context)
            {
                _context = context;
            }

            public override void Info(string message)
            {
                MigrationActivityHub.Info(_context, message);
            }

            public override void Warning(string message)
            {
                MigrationActivityHub.Warning(_context, message);
            }

            public override void Verbose(string message)
            {
                MigrationActivityHub.Verbose(_context, message);
            }
        }
    }
}
