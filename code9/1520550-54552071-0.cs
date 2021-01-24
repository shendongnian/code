    [STAThread]
    static void Main(string[] args)
    {
    
    	try
    	{
    		XpsDocument _xpsDocument = new XpsDocument(@"C:\Users\admin-\Desktop\testing.xps", System.IO.FileAccess.Read);
    		IXpsFixedDocumentSequenceReader fixedDocSeqReader = _xpsDocument.FixedDocumentSequenceReader;
    		IXpsFixedDocumentReader _document = fixedDocSeqReader.FixedDocuments[0];
    		FixedDocumentSequence sequence = _xpsDocument.GetFixedDocumentSequence();
    		string _fullPageText = "";
    
    		for (int pageCount = 0; pageCount < sequence.DocumentPaginator.PageCount; ++pageCount)
    		{
    			IXpsFixedPageReader _page = _document.FixedPages[pageCount];
    			StringBuilder _currentText = new StringBuilder();
    			System.Xml.XmlReader _pageContentReader = _page.XmlReader;
    
    			if (_pageContentReader != null)
    			{
    				while (_pageContentReader.Read())
    				{
    					if (_pageContentReader.Name == "Glyphs")
    					{
    						if (_pageContentReader.HasAttributes)
    						{
    							if (_pageContentReader.GetAttribute("UnicodeString") != null)
    							{
    								_currentText.
    								  Append(_pageContentReader.
    								  GetAttribute("UnicodeString"));
    							}
    						}
    					}
    				}
    			}
    
    			_fullPageText += _currentText.ToString();
    		}
    	}
    	catch(Exception e)
    	{
    
    	}
    }  
