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
                if (this._c.x == 0) this._c.x = 5;
            }
        }
    }
