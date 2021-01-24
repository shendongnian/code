    TextBlock tb = new TextBlock();
    var hp = new Hyperlink(new Run("error"));
    hp.Click += (s, e) => { /* do something */ };
    tb.Inlines.Add(new Run("There was as an "));
    tb.Inlines.Add(hp);
    tb.Inlines.Add(new Run(" on run"));
