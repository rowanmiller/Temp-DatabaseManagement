using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeEstateWeb.Models.Customers
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsVIP { get; set; }
    }
}
