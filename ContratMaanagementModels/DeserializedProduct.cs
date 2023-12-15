using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContratManagementModels
{
    public class DeserializedProduct
    {
        public string Id { get; set; }
        public DeserializedElement[] Elements { get; set; }

        public class DeserializedElement
        {
            public string Type { get; set; }
            public string Fee { get; set; }

            public string Price { get; set; }
        }

    }
}
