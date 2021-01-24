    void Main()
    {
    	using (var stream = new MemoryStream())
    	using (var writer = new StreamWriter(stream))
    	using (var reader = new StreamReader(stream))
    	using (var csv = new CsvReader(reader))
    	{
    		writer.WriteLine("Id,Name,IsSomething");
    		writer.WriteLine("1,one,Yes");
    		writer.WriteLine("2,two,Y");
    		writer.WriteLine("3,three,No");
    		writer.WriteLine("4,four,N");
    		writer.Flush();
    		stream.Position = 0;
    
    		csv.Configuration.RegisterClassMap<TestMap>();
    		csv.GetRecords<Test>().ToList().Dump();
    	}
    }
    
    public class Test
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public bool IsSomething { get; set; }
    }
    
    public sealed class TestMap : CsvClassMap<Test>
    {
    	public TestMap()
    	{
    		Map(m => m.Id);
    		Map(m => m.Name);
    		Map(m => m.IsSomething)
    			.TypeConverterOption(true, "Yes", "Y")
    			.TypeConverterOption(false, "No", "N");
    	}
    }
