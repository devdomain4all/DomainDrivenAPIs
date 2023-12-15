using System;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using ContratManagementModels;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContractManagementSystem.Repository
{
    public class ContractRepository : IContractRepository
    {
        private IMongoCollection<Contracts> _collection;
       
        public ContractRepository()
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
                var database = client.GetDatabase("ContractManagement");

                // Access a collection within the database
                _collection = database.GetCollection<Contracts>("Contract");

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

        public void AddContract(Contracts contract)
        {
            _collection.InsertOne(contract);
        }

        public void DeleteContract(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contracts> GetAllContracts()
        {
            throw new NotImplementedException();
        }

        public Contracts GetContractById(Guid id)
        {
            var filter = Builders<Contracts>.Filter.Eq(contract => contract.Id, id);
            var contract = _collection.Find(filter).FirstOrDefault();

            return contract;
        }

        public void UpdateContract(Contracts contract)
        {
            throw new NotImplementedException();
        }
    }
}
