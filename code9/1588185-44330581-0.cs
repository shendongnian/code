        PdfReader reader = new PdfReader(path);
        PdfReaderContentParser parser = new PdfReaderContentParser(reader);
        LocationTextExtractionStrategyEx strategy;
        string str = string.Empty;
        for (int i = 5; i <= 5; i++) // reader.NumberOfPages
        {
            strategy = parser.ProcessContent(i, new LocationTextExtractionStrategyEx("MCU_MOSI", 0));
            var x = strategy.m_SearchResultsList;
            foreach (LocationTextExtractionStrategyEx.ExtendedTextChunk chunk in strategy.m_DocChunks)
            {
                str += chunk.m_text;
                if (str.Contains("MCU_MOSI"))
                {
                    str = string.Empty;
                    Vector location = chunk.m_endLocation;
                    Console.WriteLine("Bingo"); 
                }                        
            }
        }
