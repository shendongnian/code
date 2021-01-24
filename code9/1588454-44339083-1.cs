    public class Physical
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [XmlElement("Capacity", typeof(int))]
        [XmlElement("Class", typeof(string))]
        public object[] Items
        {
            get
            {
                object[] items = new object[Class.Length * 2];
                for (int i = 0; i < items.Length; i += 2)
                {
                    items[i] = Class[i / 2];
                    items[i + 1] = Capacity[i / 2];
                }
                return items;
            }
            set
            {
                Class = new string[value.Length / 2];
                Capacity = new int[value.Length / 2];
                for (int i = 0; i < value.Length; i += 2)
                {
                    Class[i / 2] = (string)value[i];
                    Capacity[i / 2] = (int)value[i + 1];
                }
            }
        }
        [XmlIgnore]
        public string[] Class { get; set; }
        [XmlIgnore]
        public int[] Capacity { get; set; }
    }
