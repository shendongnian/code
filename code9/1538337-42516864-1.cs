	private void FillBookmark(BookmarkStart bookmark, string value)
	{
	  var text = new Text(value);
	  bookmark.RemoveAllChildren();
	  
	  IEnumerable<OpenXmlElement> elementsAfter = bookmark.ElementsAfter();
	  IEnumerable<OpenXmlElement> insideBookmark = elementsAfter.TakeWhile(element => !(element is BookmarkEnd));
	  foreach (OpenXmlElement element in insideBookmark)
	  {
	  	element.RemoveAllChildren();
	  }
	  OpenXmlElement previousSibling = bookmark.PreviousSibling();
	  while (previousSibling is BookmarkStart || previousSibling is BookmarkEnd)
	  {
	  	previousSibling = previousSibling.PreviousSibling();
	  }
	  
	  //Get previous font.
	  var runProperties = previousSibling.GetFirstChild<ParagraphMarkRunProperties>().GetFirstChild<RunFonts>();
	  //var runProperties = previousSibling.GetFirstChild<RunProperties>(); - if its simple element.
	  
	  // Clone.
	  var newProperty = (RunFonts)runProperties.Clone();
	  
	  // Create container with properties.
	  var container = new Run(text)
	  {
	  	RunProperties = new RunProperties() { RunFonts = newProperty }
	  };
	  
	  previousSibling.AppendChild(container);
	}
	    
