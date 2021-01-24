                string header = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><rss version=\"2.0\"/>";
                XDocument doc = XDocument.Parse(header);
                XElement rss = doc.Root;
                
                Boolean error = false;
                rss.Add(new XElement("channel", new object[] {
                    new XElement("title", "GetCard"),
                    new XElement("link", "10.0.0.253"),
                    new XElement("lastBuildDate", " "),
                    new XElement("generator", "Alikas Feed"),
                    new XElement("error", error),
                    new XElement("cardid", "RX0016502"),
                    new XElement("name"),
                    new XElement("passport_id", "60001082881"),
                    new XElement("tel")
                }));
                doc.Save(@"c:\temp\test.xml");
