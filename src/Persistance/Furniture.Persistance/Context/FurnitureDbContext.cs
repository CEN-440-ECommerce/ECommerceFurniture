namespace Furniture.Persistance.Context
{
	public class FurnitureDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=DESKTOP-4M0OQRD\SQLEXPRESS;Database=FurnitureDB;User Id=pixxaer;Password=453885;Encrypt=false;TrustServerCertificate=true;");
        }
        public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<File> Files { get; set; }
		public DbSet<ProductImageFile> ProductImageFiles { get; set; }
		public DbSet<InvoiceFile> InvoiceFiles { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }
		public DbSet<CompletedOrder> CompletedOrders { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Endpoint> Endpoints { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasKey(b => b.Id);

			modelBuilder.Entity<Order>()
			   .HasIndex(o => o.OrderCode)
			   .IsUnique();

			modelBuilder.Entity<Basket>()
				.HasOne(b => b.Order)
				.WithOne(o => o.Basket)
				.HasForeignKey<Order>(b => b.Id);

			base.OnModelCreating(modelBuilder);
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var datas = ChangeTracker.Entries<BaseEntity>();

			foreach (var data in datas)
			{
				switch (data.State)
				{
					case EntityState.Added:
						data.Entity.CreatedDate = DateTime.UtcNow;
						break;
					case EntityState.Modified:
						data.Entity.UpdatedDate = DateTime.UtcNow;
						break;
				}
			}

			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
