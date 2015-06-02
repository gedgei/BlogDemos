using System;
using System.Collections.Generic;
using System.Linq;

namespace EfDemo.Model
{
	public class Order
	{
		public int Id { get; private set; }
		public int CustomerId { get; private set; }
		public string Number { get; private set; }
		public DateTime LastEditedOn { get; private set; }

		public IList<OrderLine> OrderLines { get; private set; }

		protected Order()
		{
			// for EF
		}

		public Order(int customerId, string number)
		{
			if (string.IsNullOrEmpty(number))
				throw new ArgumentException("number");

			CustomerId = customerId;
			Number = number;

			LastEditedOn = DateTime.Now;

			OrderLines = new List<OrderLine>();
		}

		public void AddProduct(int productId, int quantity)
		{
			var existingLine = OrderLines.SingleOrDefault(x => x.ProductId == productId);

			if (existingLine == null)
			{
				existingLine = new OrderLine(productId, quantity);
				OrderLines.Add(existingLine);
			}
			else
			{
				existingLine.AddAdditional(quantity);
			}

			LastEditedOn = DateTime.Now;
		}

		public OrderLine RemoveProducts(int productId)
		{
			var existingLine = OrderLines.SingleOrDefault(x => x.ProductId == productId);

			if (existingLine != null)
			{
				OrderLines.Remove(existingLine);
			}

			return existingLine;
		}

		public void SetGeneratedNumber(int id)
		{
			Number = string.Format("O{0:0000}", id);
		}
	}
}
