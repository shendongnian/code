            TextBlock txt = new TextBlock();
            txt.FontSize = 32; // 24 points
            txt.Inlines.Add("This is some ");
            txt.Inlines.Add(new Italic(new Run("italic")));
            txt.Inlines.Add(" text, and this is some ");
            txt.Inlines.Add(new Bold(new Run("bold")));
            txt.Inlines.Add(" text, and let's cap it off with some ");
            txt.Inlines.Add(new Bold(new Italic (new Run("bold italic"))));
            txt.Inlines.Add(" text.");
            txt.TextWrapping = TextWrapping.Wrap;
