    private string HTMLGenerator()
    {
        // blah
        using (var sw = new StringWriter()) 
        {
            using (var writer = XmlWriter.Create(sm, settings))
            {
                xDocument.WriteTo(writer);
            }
        
            return sw.ToString();
        }
    }
