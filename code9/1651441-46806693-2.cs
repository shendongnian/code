    var xmlFromMessage = @"<Library>
        <Writer ID=""writer1""><Name>Shakespeare</Name></Writer>
        <Writer ID=""writer2""><Name>Tolkien</Name></Writer>
        <Book><WriterRef REFID=""writer1"" /><Title>King Lear</Title></Book>
        <Book><WriterRef REFID=""writer2"" /><Title>The Hobbit</Title></Book>
        <Book><WriterRef REFID=""writer2"" /><Title>Lord of the Rings</Title></Book>
         </Library>"; 
    
    var libraryDoc = XDocument.Parse(xmlFromMessage);
    
    var library = from title in libraryDoc.Descendants("Title")
        join writer in libraryDoc.Descendants("Writer")
    	on title.Parent.Element("WriterRef").Attribute("REFID").Value equals writer.Attribute("ID").Value
        select new KeyValuePair<string, string>(title.Value, writer.Value);
