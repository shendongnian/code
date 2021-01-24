    Dictionary<string, string> keyValues = new Dictionary<string, string>();
    keyValues.Add("xxxxReplacethat1", "replaced1");
    keyValues.Add("xxxxReplacethat2", "replaced2");
    
    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationFile, true))
    {
    	// Change the document's type here
    	wordDoc.ChangeDocumentType(WordprocessingDocumentType.Document);
    
    	foreach (Run rText in wordDoc.MainDocumentPart.Document.Descendants<Run>())
    	{
    		foreach (var text in rText.Elements<Text>())
    		{
    			foreach (KeyValuePair<string, string> item in keyValues)
    			{
    				Regex regexText = new Regex(item.Key);
    				text.Text = regexText.Replace(text.Text, item.Value);
    			}
    		}
    	}
    	wordDoc.Save();
    }
