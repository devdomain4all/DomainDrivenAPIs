using Microsoft.AspNetCore.Mvc;
using ContratManagementModels;
using ProductManagementSystem.Repository;
using System.Diagnostics.Contracts;
using MongoDB.Bson;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductManagementController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductManagementController> _logger;

        public ProductManagementController(ILogger<ProductManagementController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("GetProducts/{productId}")]
        public async Task<ContentResult> Get(string productId)
        {
            try
            {
                var volumeRisk = new VolumeRisk() { Type = "VolumeRisk", Fee="-33.53 EUR/MWh"};
                var crossSubsidization = new CrossSubsidization() { Type = "CrossSubsidization", Price = null };

                var productDocument = new Products();
                productDocument.Elements = new HashSet<Element>() { volumeRisk, crossSubsidization };
                productDocument.Id = Guid.Parse(productId);
                
                _repository.AddProduct(productDocument);
                Products product = _repository.GetProductById(Guid.Parse(productId));
                
                string result = JsonConvert.SerializeObject(product);
                
                return Content(result,"application/json");
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return Content(ex.Message, "application/json");
            }
        }

    }
}