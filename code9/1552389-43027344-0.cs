		abstract class Base 
		{
			public string ServiceUrl { get; }
		
			public Base(string serviceUrl)
			{
				ServiceUrl = serviceUrl;
				Console.WriteLine(ServiceUrl);
			}
		}
		class Derived : Base
		{
			public Derived(string rootUrl) : base(rootUrl + "/service")
			{
			}
		}
