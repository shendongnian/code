            // Instantiate Document object
            var pdf = new Aspose.Pdf.Document();
            //Add a page to the document
            var pdfImageSection = pdf.Pages.Add();
            DirectoryInfo dir = new DirectoryInfo(@"D:\Aspose Files\images\");
            FileInfo[] files = dir.GetFiles("*.jpg");
            //Iterate through multiple images
            foreach (var file in files)
            {
                FileStream stream = new FileStream(file.FullName, FileMode.Open);
                System.Drawing.Image img = new System.Drawing.Bitmap(stream);
                var image = new Aspose.Pdf.Image { ImageStream = stream };
                //Set appearance properties
                image.FixHeight = 300;
                image.FixWidth = 300;
                //Set margins for proper spacing and alignment
                image.Margin = new MarginInfo(5, 5, 5, 5);
                //Add the image to paragraphs of the document
                pdfImageSection.Paragraphs.Add(image);
            }
            //Save resultant document
            pdf.Save(@"D:\Aspose Files\Image2Pdf_out.pdf");
