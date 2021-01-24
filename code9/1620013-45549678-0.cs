    using (var conn = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=true; Initial Catalog=foo"))
    {
    	var result = conn.Query<Species, SpeciesCategory, WetlandIndicator, Species>(
    		"select Id = 11, Name = 'Foo', Id = 22, Name = 'Bar', Id = 33, Designation = 'House Cat' ", 
    		(species, speciesCategory, wetlandIndicator) =>
    	{
    		species.Category = speciesCategory;
    		species.WetlandIndicator = wetlandIndicator;
    		return species;
    	}).First();
    
    	Assert.That(result.Id, Is.EqualTo(11));
    
    	Assert.That(result.Category.Id, Is.EqualTo(22));
    	Assert.That(result.Category.Name, Is.EqualTo("Bar"));
    
    	Assert.That(result.WetlandIndicator.Id, Is.EqualTo(33));
    	Assert.That(result.WetlandIndicator.Designation, Is.EqualTo("House Cat"));
    }
