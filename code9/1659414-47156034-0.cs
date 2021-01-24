            var pdf = new Aspose.Pdf.Document();
            var pdfImageSection = pdf.Pages.Add();
            DirectoryInfo dir = new DirectoryInfo(@"D:\Aspose Files\images\");
            FileInfo[] files = dir.GetFiles("*.jpg");
            foreach (var file in files)
            {
                FileStream stream = new FileStream(file.FullName, FileMode.Open);
                System.Drawing.Image img = new System.Drawing.Bitmap(stream);
                var image = new Aspose.Pdf.Image { ImageStream = stream };
                image.FixHeight = 300;
                image.FixWidth = 300;
                image.Margin = new MarginInfo(5, 5, 5, 5);
                pdfImageSection.Paragraphs.Add(image);
            }
            pdf.Save(@"D:\Aspose Files\Image2Pdf_out.pdf");
