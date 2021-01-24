     [XmlType]
    public class child
    {
        private int _x = -1;
        [XmlAttribute]
        public int x { get { return this._x; } set { this._x = value; } }
        [XmlAttribute]
        public int y { get; set; }
    }
    [XmlRoot]
    public class parent
    {
        private child _c;
        [XmlElement]
        public child c { get
            {
                return this._c;
            }
            set
            {
                this._c = value;
                if (this._c.x == -1) this._c.x = 5;
            }
        }
    }
