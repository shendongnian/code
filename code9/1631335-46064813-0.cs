    using (PDFDoc doc = new PDFDoc(@"D:\in.pdf"))
    using (ElementBuilder eb = new ElementBuilder())
    using (ElementWriter writer = new ElementWriter())
    {
        int pagenum = 1;
        writer.Begin(doc.GetPage(pagenum), ElementWriter.WriteMode.e_underlay);
        Element e = eb.CreateRect(0, 0, doc.GetPage(pagenum).GetPageWidth(), doc.GetPage(pagenum).GetPageHeight());
        e.SetPathFill(true);
        e.SetPathStroke(true);
        e.SetPathClip(false);
        e.GetGState().SetFillColorSpace(ColorSpace.CreateDeviceRGB());
        e.GetGState().SetStrokeColorSpace(ColorSpace.CreateDeviceRGB());
        e.GetGState().SetStrokeColor(new ColorPt(255, 255, 255)); // white background fill color 
        e.GetGState().SetFillColor(new ColorPt(255, 255, 255)); // stroke color white as well
        writer.WritePlacedElement(e);
        writer.End();
    
        doc.Save(@"D:\output.pdf", 0);
    }
