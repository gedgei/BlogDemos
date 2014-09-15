using System;

namespace DomainContextDemo.DomainModel
{
	public abstract class DomainContextStorage
	{
		public abstract void Add(DomainContext context);
		public abstract DomainContext Get();
		public abstract void Remove();
	}

	class CallContextStorage : DomainContextStorage
	{
		[ThreadStatic]
		private static DomainContext Context;

		public override void Add(DomainContext context)
		{
			Context = context;
		}

		public override DomainContext Get()
		{
			return Context;
		}

		public override void Remove()
		{
			Context = null;
		}
	}

	[Serializable]
	public class DomainContext : IDisposable
	{
		private static DomainContextStorage storage = new CallContextStorage();

		public static DomainContext Current
		{
			get { return Storage.Get(); }
		}

		public static DomainContextStorage Storage
		{
			get { return storage; }
			set { storage = value; }
		}

		public TenantId TenantId { get; private set; }
		public string UserName { get; private set; }

		public DomainContext(TenantId tenantId, string userName)
		{
			if(Storage.Get() != null)
				throw new InvalidOperationException("Only a single Domain Context can be created!");

			TenantId = tenantId;
			UserName = userName;

			Storage.Add(this);
		}

		public void Dispose()
		{
			Storage.Remove();
		}
	}
}