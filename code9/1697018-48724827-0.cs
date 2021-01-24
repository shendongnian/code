    RenderLoop.Run(mainForm, () =>
    {
        renderTarget.BeginDraw();
        renderTarget.Clear(bgcolor);
        // get an ID2D1DeviceContext5 interface. It will fail here if Windows is not version 1704+
        using (var ctx = renderTarget.QueryInterface<DeviceContext5>())
        {
            // create WIC factory
            using (var imagingFactory = new ImagingFactory())
            {
                // load a file as a stream using WIC
                using (var file = File.OpenRead("whale.svg"))
                {
                    using (var stream = new WICStream(imagingFactory, file))
                    {
                        // create the SVG document
                        using (var doc = ctx.CreateSvgDocument(stream, new Size2F(mainForm.Width, mainForm.Height)))
                        {
                            // draw it on the device context
                            ctx.DrawSvgDocument(doc);
                        }
                    }
                }
            }
        }
        try
        {
            renderTarget.EndDraw();
        }
        catch
        {
            CreateResources();
        }
    });
