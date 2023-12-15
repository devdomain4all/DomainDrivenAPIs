using ContratManagementModels;

namespace ProductManagementSystem.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAllProducts();
        Products GetProductById(Guid id);
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(Guid id);
    }
}
