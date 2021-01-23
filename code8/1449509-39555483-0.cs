    public class MyFruit
    {
        public List<Fruit> Fruits { get; set; }
    }
    [XmlInclude(typeof(Apple))]
    [XmlInclude(typeof(Orange))]
    public abstract class Fruit
    {
        public string Name { get; set; }
    }
    public class Apple : Fruit
    {
        public string Size { get; set; }
    }
    public class Orange : Fruit
    {
        public float Price { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyFruit myFruit = new MyFruit()
            {
                Fruits = new List<Fruit>()
                {
                    new Apple() {Name = "Apple", Size = "Big"},
                    new Orange() {Name = "Orange", Price = 10.00f}
                }
            };
            string xml;
            XmlSerializer xsSubmit = new XmlSerializer(typeof(MyFruit));
            StringWriter sww = new StringWriter();
            using (XmlTextWriter writer = new XmlTextWriter(sww))
            {
                writer.Formatting=Formatting.Indented;
                xsSubmit.Serialize(writer, myFruit);
                xml = sww.ToString();
                Console.WriteLine(xml);
            }
        }
    }
