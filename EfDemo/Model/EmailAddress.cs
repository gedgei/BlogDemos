using System;
using System.Text.RegularExpressions;

namespace EfDemo.Model
{
	public class EmailAddress
	{
		public static readonly Regex Pattern = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b");

		public string Value { get; private set; }

		public EmailAddress()
		{
			// for EF
		}

		public EmailAddress(string value)
		{
			if(!Pattern.IsMatch(value))
				throw new ArgumentException("value");

			Value = value;
		}
	}
}