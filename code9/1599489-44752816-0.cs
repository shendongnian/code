	private BCAmessage DeserializeStanData(string stanresponse)
    {
        string xmlStanResponseText = Convert.ToString(Variables.xmlresponse);
        XmlSerializer serializerStan = new XmlSerializer(typeof(BCAmessage));
		BCAmessage dsResult;
        using (TextReader xmlResponseText = new StringReader(xmlStanResponseText))
        {
            dsResult = serializerStan.Deserialize(xmlResponseText);
        }
        
        return dsResult;
    }
