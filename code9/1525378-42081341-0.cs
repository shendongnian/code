    var res = new StringBuilder();
    foreach (Block r in rtb.Document.Blocks)
        {
            if (r is Paragraph) 
                foreach (Inline i in ((Paragraph)r).Inlines)
                    if (i is Run)
                    {
                        res.Append(r.ToString());
                    }
                    else if (i is InlineUIContainer)
                    {
                         res.Append(ConvertToString((Image)((InlineUIContainer)i).Child)); // you should create ConvertToString() method 
                    } 
       }
