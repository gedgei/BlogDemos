using System.Data.Entity;
using EfDemo.Model;

namespace EfDemo
{
	public class SampleDataInitializer : DropCreateDatabaseIfModelChanges<OrderingContext>
	{
		protected override void Seed(OrderingContext context)
		{
			// create and save any objects that are required when the application first starts
			context.Customers.Add(new Customer(new EmailAddress("test@test.com"), "Test Customer"));
			context.SaveChanges();
		}
	}
}