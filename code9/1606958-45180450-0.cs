    using Aspose.Words;
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc); 
            using (System.IO.StreamReader sr = new System.IO.StreamReader("./figure.htm"))
            {
                string html = sr.ReadToEnd();
                builder.InsertHtml(html);
            }
            doc.Save("d:\\DocumentBuilder.InsertTableFromHtml Out.doc");
