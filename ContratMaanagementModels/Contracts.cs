using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContratManagementModels
{
    public class Contracts
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public HashSet<Products> Products { get; set; } = new HashSet<Products>();

    }
}