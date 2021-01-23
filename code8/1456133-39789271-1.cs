        public class News
        {
            public string Imgsrc { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
            public string Date { get; set; }
            public string Text { get; set; }
            public XElement ToXml()
            {
                return new XElement("news", new object[] {
                    new XElement("Imgscr", Imgsrc),
                    new XElement("Title", Title),
                    new XElement("Link", Link),
                    new XElement("Date", Date),
                    new XElement("Text", Text),
                });
            }
        }
