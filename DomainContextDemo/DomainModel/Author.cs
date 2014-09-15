using System;

namespace DomainContextDemo.DomainModel
{
	public class Author
	{
		public string UserName { get; private set; }

		public Author(string userName)
		{
			if(string.IsNullOrEmpty(userName))
				throw new ArgumentNullException("userName");

			UserName = userName;
		}

		public override string ToString()
		{
			return string.Format("Author with username: {0}", UserName);
		}
	}
}