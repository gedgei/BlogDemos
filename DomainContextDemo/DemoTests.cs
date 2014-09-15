using DomainContextDemo.DomainModel;
using NUnit.Framework;

namespace DomainContextDemo
{
	[TestFixture]
	public class DemoTests
	{
		[SetUp]
		public void FixtureSetup()
		{
			new DomainContext(new TenantId("test"), "testuser");
		}

		[TearDown]
		public void FixtureTearDown()
		{
			DomainContext.Current.Dispose();
		}

		[Test]
		public void DemoTest()
		{
			var someEntity = new SomeEntity();

			Assert.IsNotNull(someEntity.Author);
			Assert.IsNotNull(someEntity.TenantId);
		}
	}
}
