using System;

namespace EfDemo.Model
{
	public class Customer
	{
		public int Id { get; private set; }
		public EmailAddress Email { get; private set; }
		public string FullName { get; private set; }

		protected Customer()
		{
			// for EF
		}

		public Customer(EmailAddress email, string fullName)
		{
			if(email == null)
				throw new ArgumentNullException("email");

			if (string.IsNullOrEmpty(fullName))
				throw new ArgumentException("fullName");

			this.Email = email;
			this.FullName = fullName;
		}
	}
}