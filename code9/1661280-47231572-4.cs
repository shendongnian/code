    using System.Collections;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    public class Location
    {
        public string L;
    }
    [XmlRoot("sample")]
    public class MyData
    {
        public MyData()
        {
            map = new ArrayList();
        }
        [XmlElement("url")]
        public Location[] Locations
        {
            get
            {
                Location[] items = new Location[map.Count];
                map.CopyTo(items);
                return items;
            }
            set
            {
                if (value == null)
                    return;
                Location[] items = (Location[])value;
                map.Clear();
                foreach (Location item in items)
                    map.Add(item);
            }
        }
        public int Add(Location item)
        {
            return map.Add(item);
        }
        private ArrayList map;
    }
    internal class Program
    {
