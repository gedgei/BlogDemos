using System;
using DomainContextDemo.DomainModel;

namespace DomainContextDemo
{
	class Program
	{
		static void Main()
		{
			using (new DomainContext(new TenantId("Gedgei Inc."), "Gediminas"))
			{
				var someEntity = new SomeEntity();

				Console.WriteLine(someEntity.TenantId);
				Console.WriteLine(someEntity.Author);
			}

			Console.ReadLine();
		}
	}
}
