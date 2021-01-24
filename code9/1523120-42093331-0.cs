     PdfReader reader = new PdfReader(src);
            PdfWriter writer = new PdfWriter(dest);
            // Document to be edited and documented to be merged in
            PdfDocument newDoc = new PdfDocument(reader, writer);
            PdfDocument srcDoc = new PdfDocument(new PdfReader(stampsrc));
            // CropBox And Dimensions
            Rectangle crop = newDoc.GetFirstPage().GetCropBox();
            float width = crop.GetWidth();
            float height = crop.GetHeight();
            // Create FormXObject and Canvas
            PdfFormXObject page = srcDoc.GetPage(1).CopyAsFormXObject(newDoc);
            //Extract Page Dimensions
            float xWidth = srcDoc.GetFirstPage().GetCropBox().GetWidth();
            float xHeight = srcDoc.GetFirstPage().GetCropBox().GetHeight();
            Rectangle location = new Rectangle(crop.GetLeft(), crop.GetBottom(), xWidth , xHeight );
            PdfStampAnnotation stamp = new PdfStampAnnotation(location).SetStampName(new PdfName("Logo"));
            PdfCanvas canvas = new PdfCanvas(newDoc.GetFirstPage().NewContentStreamBefore(), newDoc.GetFirstPage().GetResources(), newDoc);
           // canvas.AddXObject(page,location.GetLeft(),location.GetBottom(),page.GetWidth());
            stamp.SetNormalAppearance(page.GetPdfObject());
            stamp.SetFlags(PdfAnnotation.PRINT);
            newDoc.GetFirstPage().AddAnnotation(stamp);
            srcDoc.Close();
            newDoc.Close();
