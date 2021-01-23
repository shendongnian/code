    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var writer = new StreamWriter(stream))
    	using (var reader = new StreamReader(stream))
    	using (var csv = new CsvReader(reader))
    	{
    		writer.WriteLine("A	Bee	C");
    		writer.WriteLine("string	1	1.0");
    		writer.Flush();
    		stream.Position = 0;
    		
    		csv.Configuration.Delimiter = "	";
    		csv.Configuration.WillThrowOnMissingField = false;
    		csv.Configuration.RegisterClassMap<FooMap>();
    		csv.GetRecords<Foo>().ToList().Dump();
    	}
    }
    
    public class Foo
    {
    	public string A { get; set; }
    	public int? B { get; set; }
    	public double? C { get; set; }
    	public Guid? D { get; set; }
    }
    
    public class FooMap : CsvClassMap<Foo>
    {
    	public FooMap()
    	{
    		Map( m => m.A ).Name( "A", "Aay" );
    		Map( m => m.B ).Name( "B", "Bee" );
    		Map( m => m.C ).Name( "C", "Sea" );
    		Map( m => m.D ).Name( "D", "Dee" );
    	}
    }
