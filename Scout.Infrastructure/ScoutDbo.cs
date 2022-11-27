using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Scout.Infrastructure
{
    public class ScoutDbo
    {
        public string ScoutId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
    }

    public class Address
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
