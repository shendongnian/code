    PdfReader reader = new PdfReader(srcFile);
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms, '\0', true))
                {
                    var cropbox = reader.GetCropBox(1);
                   
                    iTextSharp.text.Image bannerImage = iTextSharp.text.Image.GetInstance(bannerUrl);
                    var rectangle = new iTextSharp.text.Rectangle(5, 5, cropbox.Width-5, 50);
                    
                    rectangle.Border = 0;
                    PdfAnnotation bannerStamp = PdfAnnotation.CreateStamp(stamper.Writer, rectangle, null, "footer");
                    bannerImage.ScaleToFit(rectangle );
                    bannerImage.SetAbsolutePosition((cropbox.Width - bannerImage.ScaledWidth)/2, 0); //align it center
                    PdfContentByte cb = stamper.GetOverContent(1);
                    PdfAppearance app = cb.CreateAppearance(rectangle.Width, rectangle.Height);
                    app.AddImage(bannerImage);
                    bannerStamp.SetAppearance(PdfName.N, app);
                    bannerStamp.Flags = PdfAnnotation.FLAGS_PRINT;
                    stamper.AddAnnotation(bannerStamp, pageNum);
                    stamper.Close();
                }
                return ms.ToArray();
            }
