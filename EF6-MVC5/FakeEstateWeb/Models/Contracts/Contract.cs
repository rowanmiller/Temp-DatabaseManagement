using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeEstateWeb.Models.Contracts
{
    public class Contract
    {
        public int ContractId { get; set; }
        public int ListingId { get; set; }
        public decimal Offer { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsClosed { get; set; }
    }
}