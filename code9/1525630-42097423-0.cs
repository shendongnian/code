    public void ReadXml(System.Xml.XmlReader reader)
    {
    	reader.MoveToContent();
        // Read attributes
    	Boolean isEmptyElement = reader.IsEmptyElement; // (1)
    	reader.ReadStartElement();
    	if (!isEmptyElement) // (1)
    	{
            // Read Child elements X and Y
    
            // Consume the end of the wrapper element
    		reader.ReadEndElement();
    	}
    }
