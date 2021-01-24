	public class TestClass
	{
		public string Property1 { get; set; }
		public string Property2 { get; set; }
		public string Property3 { get; set; }
		public string Property4 { get; set; }
		public List<dynamic> ProductList { get; set; }
	}
	class Program
	{
		public static void Main(string[] args)
		{
			TestClass obj = new TestClass();
			obj.Property1 = "p1";
			obj.Property2 = "p2";
			obj.Property3 = "p3";
			obj.Property4 = "p4";
			obj.ProductList = new List<dynamic>() { "one", "two", "three", "four" };
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, obj);
				string xmlString = textWriter.ToString();
				Console.WriteLine(textWriter);
			}
			
			Console.ReadKey();
		}
	}
