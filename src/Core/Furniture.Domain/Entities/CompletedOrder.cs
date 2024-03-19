namespace Furniture.Domain.Entities
{
    public class CompletedOrder : BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
