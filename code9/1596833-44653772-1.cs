                FileStream fs = new FileStream(@"D:\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"D:\testLogo.png");
                logo.Alignment = 6;
                doc.Add(logo);
                doc.Add(new Paragraph(@"Test"));
                doc.Close();
