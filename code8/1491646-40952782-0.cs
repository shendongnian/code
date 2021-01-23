    using (TesseractEngine engine = new TesseractEngine(@"./tessdata", "tel+tel1", EngineMode.Default))
    {
        var texts = files.AsParallel().Select(ab =>
                {
                    using (var pages = Pix.LoadFromFile(ab))
                    {
                        using (Tesseract.Page page = engine.Process(pages, eract.PageSegMode.SingleBlock))
                        {
                            return page.GetText();
                        }
                    }
                });
        foreach (string text in texts)
        {
            OCRedText.Append(text);
        }
    }
