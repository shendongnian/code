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
               private static void DoSerialize(MyData m, XmlSerializer xs)
        {
            var sww = new System.IO.StringWriter();
            XmlWriter writer = XmlWriter.Create(sww);
            xs.Serialize(writer, m);
            Console.WriteLine(sww.ToString().Replace("><", ">\r\n<"));
        }
        static void Main()
        {
            MyData m = new MyData { Locations = new Location[2] { new Location { L = "L1" }, new Location { L = "L2" } } };
            var xs = new XmlSerializer(typeof(MyData));
            var xs2 = new XmlSerializer(typeof(MyData), XmlAttributeOverride(), new Type[] { typeof(Location[]) }, RootOverride(), "");
            DoSerialize(m, xs);
            Console.WriteLine();
            DoSerialize(m, xs2);
            Console.ReadLine();
        }
        private static XmlRootAttribute RootOverride() => new XmlRootAttribute("OtherName");
        private static XmlAttributeOverrides XmlAttributeOverride()
        {
            var attrs = new XmlAttributes();
            attrs.XmlElements.Add(new XmlElementAttribute("Location"));
            var o = new XmlAttributeOverrides();
            o.Add(typeof(MyData), "Locations", attrs);
            return o;
        }
    }
