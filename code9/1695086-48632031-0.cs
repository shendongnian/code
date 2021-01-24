    public static class ReaderExtensions
    {
        public static string[] ExtractText(this PdfPage page, params Rectangle[] rects)
        {
            var textEventListener = new LocationTextExtractionStrategy();
            PdfTextExtractor.GetTextFromPage(page, textEventListener);
            string[] result = new string[rects.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = textEventListener.GetResultantText(rects[i]);
            }
            return result;
        }
        public static String GetResultantText(this LocationTextExtractionStrategy strategy, Rectangle rect)
        {
            IList<TextChunk> locationalResult = (IList<TextChunk>)locationalResultField.GetValue(strategy);
            List<TextChunk> nonMatching = new List<TextChunk>();
            foreach (TextChunk chunk in locationalResult)
            {
                ITextChunkLocation location = chunk.GetLocation();
                Vector start = location.GetStartLocation();
                Vector end = location.GetEndLocation();
                if (!rect.IntersectsLine(start.Get(Vector.I1), start.Get(Vector.I2), end.Get(Vector.I1), end.Get(Vector.I2)))
                {
                    nonMatching.Add(chunk);
                }
            }
            nonMatching.ForEach(c => locationalResult.Remove(c));
            try
            {
                return strategy.GetResultantText();
            }
            finally
            {
                nonMatching.ForEach(c => locationalResult.Add(c));
            }
        }
        static FieldInfo locationalResultField = typeof(LocationTextExtractionStrategy).GetField("locationalResult", BindingFlags.NonPublic | BindingFlags.Instance);
    }
