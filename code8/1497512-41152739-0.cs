    public class Style
    {
        public List<Color> Colors { get; set; }
        public List<Pen> Pens { get; set; }
        public void Save(string filename)
        {
            var xml = new XElement("style",
                this.Colors.Select(c => new XElement("color", c.ToArgb())),
                this.Pens.Select(p => new XElement("pen",
                    new XElement("color", p.Color.ToArgb()),
                    new XElement("width", p.Width))));
            xml.Save(filename);
        }
        public void Load(string filename)
        {
            var xml = XElement.Load(filename);
            this.Colors = xml.Elements("color")
                .Select(c => Color.FromArgb((int)c))
                .ToList();
            this.Pens = xml.Elements("pen")
                .Select(p => new Pen(
                    Color.FromArgb((int)p.Element("color")),
                    (int)p.Element("width")))
                .ToList();
        }
    }
