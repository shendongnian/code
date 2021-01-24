	using (var stream = new System.IO.StreamWriter(args[1], true))
	{
		var settings = new XmlWriterSettings();
		settings.OmitXmlDeclaration = true;
		//settings.Indent = true;
		settings.CloseOutput = false;
		
		using (var writer = XmlWriter.Create(stream, settings))
		{
			serializer.Serialize(writer, validator.MatchPossiblyValid("STRING FOR PARSING"), emptyNS);
		}
		
		stream.Write(Environment.NewLine);
		stream.Flush();
		
		using (var writer = XmlWriter.Create(stream, settings))
		{
			serializer.Serialize(writer, validator.MatchPossiblyValid("STRING FOR PARSING"), emptyNS);
		}
		//Line below throws the exception
		stream.Write(Environment.NewLine);
		stream.Flush();				
	}
