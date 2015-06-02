using System;

namespace EfDemo.Model
{
	public class OrderLine
	{
		public int Id { get; private set; }
		public int ProductId { get; private set; }
		public int Quantity { get; private set; }

		protected OrderLine()
		{
			// for EF
		}

		public OrderLine(int productId, int quantity)
		{
			if(quantity <= 0)
				throw new ArgumentOutOfRangeException("quantity");

			ProductId = productId;
			Quantity = quantity;
		}

		public void AddAdditional(int quantity)
		{
			if (quantity <= 0)
				throw new ArgumentOutOfRangeException("quantity");

			Quantity += quantity;
		}
	}
}