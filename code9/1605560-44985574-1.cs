    PrintDocument p = new PrintDocument();
              
    var font = new Font("Times New Roman", 12);
    var margins = p.DefaultPageSettings.Margins;
    var layoutArea = new RectangleF(
        margins.Left, 
        margins.Top, 
        p.DefaultPageSettings.PrintableArea.Width - (margins.Left + margins.Right ), 
        p.DefaultPageSettings.PrintableArea.Height - (margins.Top + margins.Bottom));
    var layoutSize = layoutArea.Size;
    layoutSize.Height = layoutSize.Height - font.GetHeight(); // keep lastline visible
    var brush = new SolidBrush(Color.Black);
    
    // what still needs to be printed
    var remainingText = text;
    
    p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
    {
        int charsFitted, linesFilled;
    
        // measure how many characters will fit of the remaining text
        var realsize = e1.Graphics.MeasureString(
            remainingText, 
            font, 
            layoutSize, 
            StringFormat.GenericDefault, 
            out charsFitted,  // this will return what we need
            out linesFilled);
    
        // take from the remainingText what we're going to print on this page
        var fitsOnPage = remainingText.Substring(0, charsFitted);
        // keep what is not printed on this page 
        remainingText = remainingText.Substring(charsFitted).Trim();
    
        // print what fits on the page
        e1.Graphics.DrawString(
            fitsOnPage, 
            font, 
            brush, 
            layoutArea);
    
        // if there is still text left, tell the PrintDocument it needs to call 
        // PrintPage again.
        e1.HasMorePages = remainingText.Length > 0;
    };
    p.Print();
    
