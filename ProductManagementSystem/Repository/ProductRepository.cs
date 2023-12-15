using System;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using ContratManagementModels;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ProductManagementSystem.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IMongoCollection<Products> _collection;
        
        public ProductRepository()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            var runner = MongoDbRunner.Start();

            try
            {
                string connectionString = runner.ConnectionString;

                // Create a MongoClient to connect to the embedded MongoDB instance
                var client = new MongoClient(connectionString);

                // Access a specific database
                var database = client.GetDatabase("ProductManagement");

                // Access a collection within the database
                _collection = database.GetCollection<Products>("Products");

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                //runner.Dispose(); // Stop and dispose of the embedded MongoDB instance
            }
        }

        public IEnumerable<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Products GetProductById(Guid id)
        {
            var filter = Builders<Products>.Filter.Eq(product => product.Id, id);
            var product = _collection.Find(filter).FirstOrDefault();

            return product;
        }

        public void AddProduct(Products product)
        {
            _collection.InsertOne(product);
        }

        public void UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
