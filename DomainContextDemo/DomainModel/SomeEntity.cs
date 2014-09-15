namespace DomainContextDemo.DomainModel
{
	public class SomeEntity
	{
		public TenantId TenantId { get; private set; }
		public Author Author { get; private set; }

		public SomeEntity()
		{
			this.TenantId = DomainContext.Current.TenantId;
			this.Author = new Author(DomainContext.Current.UserName);
		}
	}
}