            WebRequest request = WebRequest.Create("...");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            byte[] bytes = Convert.FromBase64String(doc.GetElementsByTagName("string")[0].InnerText);
            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
            }
