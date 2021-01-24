    var settings = new XmlReaderSettings();
	settings.Schemas = schemas;
	settings.ValidationType = ValidationType.Schema;
	settings.ValidationEventHandler += (sender, e) => 
        Console.WriteLine($"{e.Exception.LineNumber}: {e.Message}");
