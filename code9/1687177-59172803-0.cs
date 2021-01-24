            string src = @"C:\test\Test Artifact Document.pdf";
            PdfReader reader = new PdfReader(src);
            using (MemoryStream ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms))
                {
                    Dictionary<String, String> info = reader.Info;
                    using (MemoryStream msXmp = new MemoryStream())
                    {
                        XmpWriter xmp = new XmpWriter(msXmp, info);
                        xmp.SetProperty(XmpConstants.NsDC, "Firm", "FBI");
                        xmp.Close();
                        stamper.XmpMetadata = msXmp.ToArray();
                    }
                    stamper.Close();
                }
                File.WriteAllBytes(@"C:\test\Test Artifact Document (1).pdf", ms.ToArray());
            }
