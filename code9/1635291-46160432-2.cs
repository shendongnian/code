    class Program
    {
    	static void Main(string[] args)
    	{
    	  var serializeTest = new Test<Sub1> { TestId = 1, Name = "Test", Shipments = new List<Sub1> { new Sub1 { Id = 1, Desc = "Test" }, new Sub1 { Id = 2, Desc = "Test2" } } };
    	  var serializeTest2 = new Test<Sub2> { TestId = 1, Name = "Test", Shipments = new List<Sub2> { new Sub2 { IdWhatever = 1, DescWhatever = "Test" }, new Sub2 { IdWhatever = 2, DescWhatever = "Test2" } } };
    	  var serialized = serializeTest.SerializeToXml();
    	  var serialized2 = serializeTest2.SerializeToXml();
          var deserialized = serialized.DeserializeXml<Test<Sub1>>();
          var deserialized2 = serialized2.DeserializeXml<Test<Sub2>>();
    
    	  Console.WriteLine(serialized);
    	  Console.WriteLine();
    	  Console.WriteLine(serialized2);
    	  Console.ReadLine();
    	}
    }
