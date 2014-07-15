﻿using System.Collections.Generic;

namespace FakeEstateWeb.Models.Listings
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsLicensed { get; set; }

        public List<Listing> Listings { get; set; }
    }
}