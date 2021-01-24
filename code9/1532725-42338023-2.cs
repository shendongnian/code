    [System.Serializable]
    [System.Xml.Serialization.XmlRoot("Color")]
    public class UIColor
    {
        public UIColor()
        {
            name = "Col1"
        }
        public UIColor(double red, double green, double blue, double alpha)
        {
            r = (float)red;
            g = (float)green;
            b = (float)blue;
            a = (float)alpha;
            name = "Col1";
        }
        public UIColor(double white, double alpha)
        {
            r = (float)white;
            g = (float)white;
            b = (float)white;
            a = (float)alpha;
            name = "Col1";
        }
        [System.Xml.Serialization.XmlAttribute]
        public string name
        {
            get;
            set;
        }
        [System.Xml.Serialization.XmlAttribute]
        public float r
        {
            get;
            set;
        }
        [System.Xml.Serialization.XmlAttribute]
        public float g
        {
            get;
            set;
        }
        [System.Xml.Serialization.XmlAttribute]
        public float b
        {
            get;
            set;
        }
        [System.Xml.Serialization.XmlAttribute("alpha")]
        public float a
        {
            get;
            set;
        }
    }
