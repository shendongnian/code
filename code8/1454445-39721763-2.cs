    var maxHeight = doc.PageSetup.PageHeight - doc.PageSetup.BottomMargin;
    foreach (Word.Shape shape in doc.Shapes)
    {
    	//scale to 97.2%
    	shape.Width = (float)0.972*shape.Width;
    	shape.Height = (float) 0.972*shape.Height;
    
    	var pos = (float)shape.Anchor.Information[Word.WdInformation.wdVerticalPositionRelativeToPage];
    	var curPage = (int)shape.Anchor.Information[Word.WdInformation.wdActiveEndPageNumber];
    	if (pos > maxHeight)
    	{
    		//Re-set position of shape to top left before cut/paste:
    		shape.RelativeHorizontalPosition = Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionPage;
    		shape.RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionPage;
    		shape.Left = WdApp.InchesToPoints((float)0.889);
    		shape.Top = WdApp.InchesToPoints((float)0.374);
    		shape.Select();
    		WdApp.Selection.Cut();
    		WdApp.Selection.GoTo(Word.WdGoToItem.wdGoToPage, curPage + 1);
    		WdApp.Selection.Paste();
    	}
    }
    foreach (Word.InlineShape inline in doc.InlineShapes)
    {
    	//scale to 97.2%
    	inline.Width = (float)0.972 * inline.Width;
    	inline.Height = (float)0.972 * inline.Height;
    }
