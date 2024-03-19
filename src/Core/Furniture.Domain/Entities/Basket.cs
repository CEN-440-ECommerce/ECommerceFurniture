﻿namespace Furniture.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public int UserId { get; set; }

        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
