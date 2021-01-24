    List<Rectangle> GetSegmentedRegions(Bitmap image, PageIteratorLevel level)
    {
        using (var engine = new TesseractEngine(Datapath, Language, EngineMode.Default))
        {
            using (var page = engine.Process(image))
            {
                List<Rectangle> boxes = page.GetSegmentedRegions(level);
                return boxes;
            }
        }
    }
