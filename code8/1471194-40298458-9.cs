		public object Execute(AppDomain domain, Func<object, object> toExecute, params object[] parameters)
		{
			var t = typeof(Proxy); // add me
			var args = new object[] {toExecute, parameters};
			var proxy = domain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName, false,
				BindingFlags.Default, 
				null,
				args,
				null,
				null) as Proxy; // add me
			
			//var proxy = new Proxy(toExecute, parameters);
			var result = proxy.Invoke(domain);
			return result;
		}
