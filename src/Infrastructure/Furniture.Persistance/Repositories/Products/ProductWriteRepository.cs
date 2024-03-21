namespace Furniture.Persistance.Repositories.Products
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(FurnitureDbContext context) : base(context)
        {
        }
    }
}
