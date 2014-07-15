using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeEstateWeb.Models.Contracts
{
    public class ContractContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
    }
}