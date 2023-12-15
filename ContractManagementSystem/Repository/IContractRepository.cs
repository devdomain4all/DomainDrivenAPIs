using ContratManagementModels;
using System.Diagnostics.Contracts;

namespace ContractManagementSystem.Repository
{
    public interface IContractRepository
    {
        IEnumerable<Contracts> GetAllContracts();
        Contracts GetContractById(Guid id);
        void AddContract(Contracts contract);
        void UpdateContract(Contracts contract);
        void DeleteContract(Guid id);
    }
}
