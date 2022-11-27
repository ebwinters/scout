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
        public string id { get; set; } = string.Empty;
        public string scoutId { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string imageUrl { get; set; } = string.Empty;
        public string notes { get; set; } = string.Empty;
        public Address address { get; set; } = new Address();
    }

    public class Address
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
