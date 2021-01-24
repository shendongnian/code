    [XmlRoot("map")]
    public class XMLMAP
    {
        [XmlAttribute("version")]
        public string Version;
        [XmlAttribute("orientation")]
        public string Orientation;
        [XmlAttribute("renderorder")]
        public string Renderorder;
        [XmlAttribute("width")]
        public int Width;
        [XmlAttribute("height")]
        public int Height;
        [XmlAttribute("tilewidth")]
        public int Tilewidth;
        [XmlAttribute("tileheight")]
        public int TileHeight;
        [XmlAttribute("nextobjectid")]
        public int NextObjectID;
        [XmlElement("tileset")]
        public List<TileSet> TileSets;
    }
    [XmlRoot("tileset")]
    public class TileSet
    {
        [XmlAttribute("firstgid")]
        public string FirstGID;
    }
