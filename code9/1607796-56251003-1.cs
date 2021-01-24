    FileStream stream = new FileStream("E:\\Testingfolder\\u3dpdf\\DoctoPdf.pdf", FileMode.Open, FileAccess.Read);
            String RESOURCE;
            RESOURCE = "E:\\Testingfolder\\u3dpdf\\Testu3d.u3d";
            iTextSharp.text.Rectangle rect;
            using (iTextSharp.text.Document document = new iTextSharp.text.Document())
            {
                PdfWriter pdfwriter = PdfWriter.GetInstance(document, stream);
                
                // step 3
                document.Open();
                // step 4
                rect = new iTextSharp.text.Rectangle(100, 400, 500, 800);
                rect.Border = iTextSharp.text.Rectangle.BOX;
                rect.BorderWidth = 0.5f;
                rect.BorderColor = new BaseColor(0xFF, 0x00, 0x00);
                document.Add(rect);
                document.SetMargins(129,259,647,1416);
                PdfIndirectObject streamObject = null;
                using (FileStream fs =
                    new FileStream(RESOURCE, FileMode.Open, FileAccess.Read))
                {
                    PdfStream stream3D = new PdfStream(fs, pdfwriter);
                    stream3D.Put(PdfName.TYPE, new PdfName("3D"));
                    stream3D.Put(PdfName.SUBTYPE, new PdfName("U3D"));
                    stream3D.FlateCompress();
                    streamObject = pdfwriter.AddToBody(stream3D);
                    stream3D.WriteLength();
                }
                PdfDictionary dict3D = new PdfDictionary();
                dict3D.Put(PdfName.TYPE, new PdfName("3DView"));
                dict3D.Put(new PdfName("XN"), new PdfString("Default"));
                dict3D.Put(new PdfName("IN"), new PdfString("Unnamed"));
                dict3D.Put(new PdfName("MS"), PdfName.M);
                dict3D.Put(new PdfName("C2W"),
                        new PdfArray(new float[] { 1, 0, 0, 0, 0, -1, 0, 1, 0, 3, -235, 28 }));
                dict3D.Put(PdfName.CO, new PdfNumber(235));
                PdfIndirectObject dictObject = pdfwriter.AddToBody(dict3D);
                PdfAnnotation annot = new PdfAnnotation(pdfwriter, rect);
                annot.Put(PdfName.CONTENTS, new PdfString("3D Model"));
                annot.Put(PdfName.SUBTYPE, new PdfName("3D"));
                annot.Put(PdfName.TYPE, PdfName.ANNOT);
                annot.Put(new PdfName("3DD"), streamObject.IndirectReference);
                annot.Put(new PdfName("3DV"), dictObject.IndirectReference);
                PdfAppearance ap = pdfwriter.DirectContent.CreateAppearance(
                    rect.Width, rect.Height
                );
                annot.SetAppearance(PdfAnnotation.APPEARANCE_NORMAL, ap);
                annot.SetPage();
                pdfwriter.AddAnnotation(annot);
                
            }
