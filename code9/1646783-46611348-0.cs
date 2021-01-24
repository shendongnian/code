    void Main()
    {
    	var text = CreateTestDoc();
    	// Console.WriteLine(text); //	Proof the config file is value.
    	
    	var xDoc = XDocument.Load(new StringReader(text));
    	var cars = xDoc.Root.Element("cars").Descendants();
    	foreach (var car in cars)
    	{
    		Console.WriteLine($"Car Config Name: {car.Attribute("name").Value}, " +
    						  $"Path: {car.Attribute("value").Value}");
    	}	
    }
    // Define other methods and classes here
    public string CreateTestDoc()
    {
    	return (new XDocument(new XElement("config", 
    		new XElement("cars", 
    			new XElement("car", 
    				new XAttribute("name", "SuvConfig"),
    				new XAttribute("value", "SuvPath")),
    			new XElement("car",
    				new XAttribute("name", "SedanConfig"),
    				new XAttribute("value", "SedanPath"))
    		)))).ToString();
    }
