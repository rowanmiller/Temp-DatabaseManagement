using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace FakeEstateWeb.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Databases()
        {
            // TODO: Find types from all assemblies
            var contexts = this.GetType()
                .Assembly
                .GetTypes()
                .Where(t => typeof(DbContext).IsAssignableFrom(t));

            var result = new List<DatabaseViewModel>();
            foreach (var context in contexts)
            {
                // TODO: Deal with non-default ctors
                using (var db = (DbContext)Activator.CreateInstance(context))
                {
                    var model = new DatabaseViewModel
                    {
                        ContextName = context.Name,
                        ContextAssemblyQualifiedName = context.AssemblyQualifiedName,
                        DatabaseExists = db.Database.Exists()
                    };

                    var configBaseType = typeof(DbMigrationsConfiguration<>).MakeGenericType(context);
                    var configType = context.Assembly.GetTypes().SingleOrDefault(t => configBaseType.IsAssignableFrom(t));
                    if(configType != null)
                    {
                        model.MigrationsEnabled = true;
                        model.MigrationsConfigurationAssemblyQualifiedName = configType.AssemblyQualifiedName;

                        var config = (DbMigrationsConfiguration)Activator.CreateInstance(configType);
                        var migrator = new DbMigrator(config);
                        model.PendingMigrations = migrator.GetPendingMigrations();

                        // We can only check for model changes if the database exists
                        // This restriction should be removed in EF7 as we can just check the snapshot file
                        if(model.DatabaseExists)
                        {
                            model.PendingModelChanges = !db.Database.CompatibleWithModel(throwIfNoMetadata: false);
                        }
                    }

                    result.Add(model);
                }
            }

            return View(result);
        }

        public class DatabaseViewModel
        {
            public DatabaseViewModel()
            {
                this.PendingMigrations = new List<string>();
            }

            public string ContextName { get; set; }
            public string ContextAssemblyQualifiedName { get; set; }
            public bool DatabaseExists { get; set; }

            public bool MigrationsEnabled { get; set; }
            public string MigrationsConfigurationAssemblyQualifiedName { get; set; }
            public bool PendingModelChanges { get; set; }
            public IEnumerable<string> PendingMigrations { get; set; }
        }
    }
}