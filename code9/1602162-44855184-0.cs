    [XmlType]
    public class Child
    {
        private int x;
        public Child()
        {
            x = 10;
            UsingDefaulXValue = true;
            Y = -100;
        }
        [XmlAttribute]
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                UsingDefaulXValue = false;
            }
        }
        [XmlIgnore]
        public bool UsingDefaulXValue { get; private set; }
        [XmlAttribute]
        public int Y { get; set; }
    }
    [XmlRoot]
    public class Parent
    {
        private const int DefaultX = 5;
        private Child c;
        public Parent()
        {
            // Careful to use property and not field
            C = new Child();
        }
        [XmlElement]
        public Child C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                if (c.UsingDefaulXValue)
                {
                    c.X = DefaultX;
                }
            }
        }
    }
