	public class HelloWorldAttribute : System.Attribute  
	{  
		private string _someString;
		public HelloWorldAttribute(string text)  
		{  
			_someString = text;
		}  
		
		public void OnBeforeExecute()
		{
			Console.WriteLine("OnBeforeExecute says '{0}'.", _someString);
		}
	}  
	
