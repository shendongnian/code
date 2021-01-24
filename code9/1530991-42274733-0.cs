    using (var engine = new TesseractEngine(@".\tessdata", "ita", EngineMode.TesseractAndCube))
    {
        using (var img = Pix.LoadFromFile(sourceFilePath))
        {
            using (var page = engine.Process(img))
            {
                var text = page.GetText();                        
            }
        }
    }
