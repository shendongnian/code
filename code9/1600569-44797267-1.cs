	public class MyControllerConfig : Attribute, IControllerConfiguration
	{
		private readonly string _prefix;
		private readonly string _ns;
		public MyControllerConfig(string prefix, string ns)
		{
			_prefix = prefix;
			_ns = ns;
		}
		public void Initialize(HttpControllerSettings controllerSettings,
								HttpControllerDescriptor controllerDescriptor)
		{
			var formatter = new CustomXmlFormatter { UseXmlSerializer = true };
			formatter.Namespaces.Add(_prefix, _ns);
			controllerSettings.Formatters.Clear();
			controllerSettings.Formatters.Add(formatter);
		}
	}
