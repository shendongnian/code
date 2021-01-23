    string[] lines = "0\n1\n    2\n        3\n".Split(
        new string[] { "\n" }, 
        StringSplitOptions.RemoveEmptyEntries
    );
    p = new Paragraph().AddStyle(
        new Style().SetFont(PdfFontFactory.CreateFont(FontConstants.COURIER))
    );
    foreach (var l in lines)
    {
        if (Regex.IsMatch(l, @"^\s+"))
        {
            p.Add(" ")  // all spaces stripped, whether one or more characters
                .Add(l) // now leading whitespace preserved
                .Add("\n");
        }
        else
        {
            p.Add(l).Add("\n");
        }
    }
    doc.Add(p);
