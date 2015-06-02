using System.Data.Entity;
using EfDemo.Model;

namespace EfDemo
{
	public class OrderingContext: DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer<OrderingContext>(new SampleDataInitializer());

			base.OnModelCreating(modelBuilder);
		}
	}
}
