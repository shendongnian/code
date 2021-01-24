	public class HelloWorldAttribute : System.Attribute  
	{  
		private string _someString;
		public HelloWorldAttribute(string text)  
		{  
			_someString = text;
		}  
		
		public void MyAttributeMethod()
		{
			Console.WriteLine("HelloWorldAttribute says '{0}'.", _someString);
		}
	}  
	
