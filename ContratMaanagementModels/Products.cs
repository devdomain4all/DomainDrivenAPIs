
using System.Collections.Generic;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ContratManagementModels
{

    public class Products
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Elements")]
        public HashSet<Element> Elements { get; set; } = new HashSet<Element>();
    }
}
