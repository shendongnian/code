    byte[] password = System.Text.ASCIIEncoding.ASCII.GetBytes(pdfPass);
            PdfReader reader1 = new PdfReader(src, password);
            PdfReader reader2 = new PdfReader(src, password);
            int n = reader1.NumberOfPages;
            PdfDictionary pageDict1;
            PdfDictionary pageDict2;
            PdfRectangle rect1;
            PdfRectangle rect2;
            //For Old Aadhar Card
            if (PdfType == "Old")
            {
                rect1 = new PdfRectangle(10, 50, 300, 270);
                rect2 = new PdfRectangle(290, 50, 590, 270);
            }
            else 
            {
                rect1 = new PdfRectangle(10, 50, 500, 270);
                rect2 = new PdfRectangle(290, 50, 590, 270);
            }
            //For New Aadhar Card
            //PdfRectangle rect = new PdfRectangle(10, 40, 570, 270);
            for (int i = 1; i <= n; i++)
            {
                pageDict1 = reader1.GetPageN(i);
                pageDict1.Put(PdfName.CROPBOX, rect1);
            }
            for (int i = 1; i <= n; i++)
            {
                pageDict2 = reader2.GetPageN(i);
                pageDict2.Put(PdfName.CROPBOX, rect2);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                PdfStamper stamper1 = new PdfStamper(reader1, new FileStream(@"D:\testpdfnew1.pdf", FileMode.Create));
                PdfStamper stamper2 = new PdfStamper(reader2, new FileStream(@"D:\testpdfnew2.pdf", FileMode.Create));
                stamper1.Close();
                stamper2.Close();
                reader1.Close();
                reader2.Close();
            }
