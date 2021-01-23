       public class News
        {
            public string Imgsrc { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
            public string Date { get; set; }
            public string Text { get; set; }
            public XElement xml { get; set; }
            public void ToXml()
            {
                xml = new XElement("News", new object[] {
                    new XElement("Imgscr", Imgsrc),
                    new XElement("Title", Title),
                    new XElement("Link", Link),
                    new XElement("Date", Date),
                    new XElement("Text", Text),
                });
            }
        }
