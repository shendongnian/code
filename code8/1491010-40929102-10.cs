    private List<RectangleF> MeasureCharacters(Graphics gr,Font font, int      
                                               posY,string text)
    {
        List<RectangleF> results = new List<RectangleF>();
        // The X location for the next character.
        float x = 0;
        // Get the character sizes 31 characters at a time.
        for (int start = 0; start < text.Length; start += 32)
        {
            // Get the substring.
            int len = 32;
            if (start + len >= text.Length) len = text.Length - start;
            string substring = text.Substring(start, len);
            // Measure the characters.
            List<RectangleF> rects =
                MeasureCharactersInWord(gr, font, substring);
            // Remove lead-in for the first character.
            if (start == 0) x += rects[0].Left;
            // Save all but the last rectangle.
            for (int i = 0; i < rects.Count + 1 - 1; i++)
            {
                RectangleF new_rect = new RectangleF(
                    x, posY,
                    rects[i].Width, rects[i].Height);
                results.Add(new_rect);
                // Move to the next character's X position.
                x += rects[i].Width;
            }
        }
        // Return the results.
        return results;
    }
