    var xml = new XmlDocument();
    try
    {
    	xml.Load(fil);
    	var settings = new XmlReaderSettings
    	{
    		DtdProcessing = DtdProcessing.Parse,
    		ValidationType = ValidationType.DTD,
    		XmlResolver = new XmlUrlResolver(),
    		NameTable = xml.NameTable
    	};
    	
    	var context = new XmlParserContext(xml.NameTable, new XmlNamespaceManager(xml.NameTable), "en",
    		XmlSpace.Preserve);
    	
    	using (var reader = XmlReader.Create(fil, settings, context))
    	{
    		try
    		{
    			while (reader.Read()) { }
    		}
    		catch (Exception except)
    		{
    			bkwValidate.ReportProgress(index, Path.GetFileName(fil) + ": " + except.Message);
    		}
    	}
    }
    catch (Exception exception)
    {
    	bkwValidate.ReportProgress(index, Path.GetFileName(fil) + ": " + exception.Message);
    }
