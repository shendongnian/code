    using (var engine = new TesseractEngine(Path.Combine(HttpRuntime.AppDomainAppPath,"tessdata"), "eng", EngineMode.Default))
        {
            // have to load Pix via a bitmap since Pix doesn't support loading a stream.
            using (var image = new System.Drawing.Bitmap(file.InputStream))
            {
                using (var pix = PixConverter.ToPix(image))
                {
    
                    using (var page = engine.Process(pix))
                    {
    
                    }
                }
            }
        }
