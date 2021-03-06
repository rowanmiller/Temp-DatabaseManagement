using FakeEstateWeb.Models.Customers;
using FakeEstateWeb.Models.Listings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FakeEstateWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            if (exception is System.Data.Entity.Core.EntityException
                && exception.InnerException is System.Data.SqlClient.SqlException
                && ((System.Data.SqlClient.SqlException)exception.InnerException).ErrorCode == -2146232060)
            {
                Response.Redirect(@"~/Management/Databases?database_error=true&return_url=" + Request.Url);
            }
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ListingsContext>(null);
            Database.SetInitializer<CustomerContext>(null);

            var migrator = new DbMigrator(new Migrations.Listings.ListingsConfig());
            migrator.Update("ListingStatus");

            using (var db = new CustomerContext())
            {
                db.Database.Delete();
            }
        }
    }
}






