    void Run()
    {
        PdfReader reader = new PdfReader("/path/to/input.pdf");
        var s = PdfTextExtractor.GetTextFromPage(reader, 1, new LocationTextExtractionStrategy(new Local()));
    }
    private class Local : LocationTextExtractionStrategy.ITextChunkLocationStrategy
        {
        public LocationTextExtractionStrategy.ITextChunkLocation CreateLocation(TextRenderInfo renderInfo, LineSegment baseline)
        {
            // you need the info per character, so iterate all characters per TextRenderInfo
            foreach (TextRenderInfo tr in renderInfo.GetCharacterRenderInfos())
            {
                LineSegment bl = tr.GetBaseline();
                // do something with the info
                Console.WriteLine(tr.GetText() + " @ (" + bl.GetStartPoint()[Vector.I1] + ", " + bl.GetStartPoint()[Vector.I2] + ")");
            }
            return new LocationTextExtractionStrategy.TextChunkLocationDefaultImp(baseline.GetStartPoint(), baseline.GetEndPoint(), renderInfo.GetSingleSpaceWidth());
        }
    }
