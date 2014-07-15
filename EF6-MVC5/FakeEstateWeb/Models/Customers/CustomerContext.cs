using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace FakeEstateWeb.Models.Customers
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("name=CustomerContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}
