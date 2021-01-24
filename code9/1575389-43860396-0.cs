    public class Root
    {
        [XmlIgnore]
        public item item { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAnyElement("item")]
        public List<XElement> _item
        {
            get
            {
                return item.color.Select(i =>
                    new XElement("item",
                        new XElement("name", item.name),
                        new XElement("itemColor", i.itemColor)
                    )).ToList();
            }
        }
    }
    public class item
    {
        public string name { get; set; }
        public color[] color;
    }
    public class color
    {
        public string itemColor { get; set; }
    }
