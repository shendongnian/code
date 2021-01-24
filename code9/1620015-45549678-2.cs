    public class Species
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public SpeciesCategory Category { get; set; }
    	public WetlandIndicator WetlandIndicator { get; set; }
    }
    
    public class SpeciesCategory
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public class WetlandIndicator
    {
    	public string Code { get; set; }
    	public string Designation { get; set; }
    	public bool Status { get; set; }
    }
    
    using (var conn = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=true; Initial Catalog=foo"))
    {
    	var result = conn.Query<Species, SpeciesCategory, WetlandIndicator, Species>(
    		"select Id = 11, Name = 'Foo', Id = 22, Name = 'Bar', Code = 'X', Designation = 'House Cat' ", 
    		(species, speciesCategory, wetlandIndicator) =>
    	{
    		species.Category = speciesCategory;
    		species.WetlandIndicator = wetlandIndicator;
    		return species;
    	}, splitOn: "Id, Code").First();
    
    	Assert.That(result.Id, Is.EqualTo(11));
    
    	Assert.That(result.Category.Id, Is.EqualTo(22));
    	Assert.That(result.Category.Name, Is.EqualTo("Bar"));
    
    	Assert.That(result.WetlandIndicator.Code, Is.EqualTo("X"));
    	Assert.That(result.WetlandIndicator.Designation, Is.EqualTo("House Cat"));
    }
