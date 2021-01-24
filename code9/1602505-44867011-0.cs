    PrivateFontCollection collection = new PrivateFontCollection();
        // Add the custom font families. 
        // (Alternatively use AddMemoryFont if you have the font in memory, retrieved from a database).
        collection.AddFontFile(@"E:\Downloads\actest.ttf");
        using (var g = Graphics.FromImage(bm))
        {
            // Create a font instance based on one of the font families in the PrivateFontCollection
            Font f = new Font(collection.Families.First(), 16);
            g.DrawString("Hello fonts", f, Brushes.White, 50, 50);
        }
