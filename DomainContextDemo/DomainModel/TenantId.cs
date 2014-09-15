using System;

namespace DomainContextDemo.DomainModel
{
	public class TenantId
	{
		public string Value { get; set; }

		public TenantId(string tenantId)
		{
			if(string.IsNullOrEmpty(tenantId))
				throw new ArgumentNullException("tenantId");

			Value = tenantId;
		}

		public override string ToString()
		{
			return string.Format("Tenant with ID: {0}", Value);
		}
	}
}