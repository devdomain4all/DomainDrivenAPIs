using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratManagementModels
{
    // Element entity (VolumeRisk, CrossSubsidization, etc.)
    //[BsonKnownTypes(typeof(VolumeRisk), typeof(CrossSubsidization))]
    //[BsonDiscriminator(RootClass = true)]
    //[BsonNoId]
    //[BsonIgnoreExtraElements]
    
    public class Element
    {
        //[BsonElement("_t")]
        [JsonProperty("Type")] 
        public string Type { get; set; }
        //[BsonElement("fee")]
        //[JsonProperty("Fee", NullValueHandling = NullValueHandling.Ignore)]
        //public string? Fee { get; set; }

        ////[BsonElement("price")]
        //[JsonProperty("Price",NullValueHandling =NullValueHandling.Ignore)]
        //public decimal? Price { get; set; }
    }
    //[BsonNoId]
    //[BsonIgnoreExtraElements]
    public class VolumeRisk : Element
    {
        //[BsonElement("fee")]
        [JsonProperty("Fee")] 
        public string Fee { get; set; }
    }
    //[BsonNoId]
    //[BsonIgnoreExtraElements]
    public class CrossSubsidization : Element
    {
        //[BsonElement("price")]
        [JsonProperty("Price")] 
        public string Price { get; set; }
    }

}
