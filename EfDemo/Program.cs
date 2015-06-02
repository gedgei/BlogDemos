using System;
using System.Data.Entity;
using System.Linq;
using EfDemo.Model;

namespace EfDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			int orderId;
			const int productId = 1;

			using (var context = new OrderingContext())
			{
				var customer = context.Customers.First();

				Console.WriteLine("Customer from DB with ID: {0}", customer.Id);

				var order = new Order(customer.Id, "123456");
				order.AddProduct(productId, 12);
				order.AddProduct(productId, 7);

				context.Orders.Add(order);
				context.SaveChanges();

				// generate order number from it's ID
				order.SetGeneratedNumber(order.Id);
				context.SaveChanges();

				Console.WriteLine("New order number: {0}", order.Number);

				orderId = order.Id;
				
				Console.WriteLine("Order saved with ID: {0}", orderId);
			}

			using (var context = new OrderingContext())
			{
				var order = context.Orders.Include("OrderLines").Single(x => x.Id == orderId);
				Console.WriteLine("Order number from db: {0}", order.Number);

				var removedOrderLine = order.RemoveProducts(productId);

				// a hack, so that EF would remove row from database
				context.Entry(removedOrderLine).State = EntityState.Deleted;
				context.SaveChanges();
			}

			Console.Read();
		}
	}
}
