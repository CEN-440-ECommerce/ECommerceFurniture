namespace Furniture.Persistance.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(FurnitureDbContext context) : base(context)
        {
        }
    }
}
