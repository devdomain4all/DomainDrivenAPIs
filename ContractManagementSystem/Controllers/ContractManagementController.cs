using Microsoft.AspNetCore.Mvc;
using ContratManagementModels;
using ContractManagementSystem.Repository;
using System.Text.Json;
using System;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static ContratManagementModels.DeserializedProduct;

namespace ContractManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractManagementController : ControllerBase
    {

        private readonly ILogger<ContractManagementController> _logger;
        private readonly IContractRepository _contractRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public ContractManagementController(ILogger<ContractManagementController> logger,
            IContractRepository repository,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _contractRepository = repository;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet("GetContract/{contractId}")]
        public async Task<ContentResult> Get(string contractId)
        {
            try
            {
                Guid id = Guid.NewGuid();
                var contractDocument = new Contracts
                {
                    Id = id,
                    Name = "contractname",
                    CountryId = 4

                };
                _contractRepository.AddContract(contractDocument);

                var contract = _contractRepository.GetContractById(id);
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("User-Agent", "YourUserAgent");

                // Replace "https://localhost:XXXX/api/products" with the actual URL of your ProductsController
                var response = httpClient.GetAsync($"http://localhost:5146/ProductManagement/GetProducts/{id}").Result; ;

                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();

                    string unescapedString = Regex.Unescape(content);
                    var product1 = JsonConvert.DeserializeObject<DeserializedProduct>(content);
                    var product = JsonConvert.DeserializeObject<Products>(content);

                    Products products = new();
                    products.Id = Guid.Parse(product1.Id);

                    Parallel.ForEach<DeserializedElement>(product1.Elements, item =>
                    {
                        if (item.Type == "VolumeRisk")
                        {
                            VolumeRisk volRisk = new VolumeRisk() { Type = item.Type, Fee = item.Fee };
                            products.Elements.Add(volRisk);
                        }
                        else if (item.Type == "CrossSubsidization")
                        {
                            CrossSubsidization crossSub = new CrossSubsidization() { Type = item.Type, Price = item.Price };
                            products.Elements.Add(crossSub);
                        }
                    });

                    contract.Products.Add(products);

                }
                string result = JsonConvert.SerializeObject(contract);
                return Content(result, "application/json");
            }
            catch (Exception ex)
            {
                return Content(ex.Message, "application/json");
            }


        }

        //[HttpGet(Name = "GetContract")]
        //public IEnumerable<Contracts> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new Contracts
        //    {
        //        //Date = DateTime.Now.AddDays(index),
        //        //TemperatureC = Random.Shared.Next(-20, 55),
        //        //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}