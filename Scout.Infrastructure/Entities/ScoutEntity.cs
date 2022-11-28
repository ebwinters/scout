using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Scout.Infrastructure.Entities
{
    public class ScoutEntity
    {
        [Key]
        [JsonProperty("scoutId")]
        public string scoutId { get; set; } = string.Empty;

        [StringLength(50)]
        [JsonProperty("title")]
        public string title { get; set; } = string.Empty;

        [StringLength(100)]
        [JsonProperty("imageUrl")]
        public string imageUrl { get; set; } = string.Empty;

        [StringLength(150)]
        [JsonProperty("notes")]
        public string notes { get; set; } = string.Empty;

        [JsonProperty("address")]
        public Address address { get; set; } = new Address();

    }

    public class Address
    {
        [JsonProperty("longitude")]
        public double longitude { get; set; }
        [JsonProperty("latitude")]
        public double latitude { get; set; }
    }
}
