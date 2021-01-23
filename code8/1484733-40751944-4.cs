    void Main()
    {
    	var rootDirectory = @"C:\Testing";
    	var schemaDirectory = Path.Combine(rootDirectory, "Schemas");
    	var dataDirectory = Path.Combine(rootDirectory, "Data");
    
    	var schemaFiles = new[] {
    		Path.Combine(schemaDirectory, "IQ.xsd"),
    		Path.Combine(schemaDirectory, "IMR.xsd"),
    		Path.Combine(schemaDirectory, "RP.xsd")
    	};
    
    	var dataFiles = new[] {
    		Path.Combine(dataDirectory, "IQ.xml"),
    		Path.Combine(dataDirectory, "IMR.xml"),
    		Path.Combine(dataDirectory, "RP.xml")
    	};
    
    	var results = FindMatchingSchemas(dataFiles[1], schemaFiles).Dump();
    	Console.WriteLine("Matching schema is: {0}", results.First(r => r.Value));
    }
    
    private static Dictionary<string, bool> FindMatchingSchemas(string dataFile, string[] schemaFiles)
    {
    	var results = new Dictionary<string, bool>();
    	
    	foreach (var schemaFile in schemaFiles)
    	{
    		results.Add(schemaFile, true);
    		
    		// Set the validation settings.
    		XmlReaderSettings settings = new XmlReaderSettings();
    		settings.ValidationType = ValidationType.Schema;
    		settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
    		settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
    		settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    		settings.ValidationEventHandler += new ValidationEventHandler((object sender, ValidationEventArgs args) =>
    		{
    			// Validation error
    			results[schemaFile] = false;
    		});
    		settings.Schemas.Add(null, schemaFile);
    
    		// Create the XmlReader object.
    		XmlReader reader = XmlReader.Create(dataFile, settings);
    
    		// Parse the file.
    		while (reader.Read());
    	}
    	
    	return results;
    }
    // Output: Matching schema is: C:\Testing\Schemas\IMR.xsd
