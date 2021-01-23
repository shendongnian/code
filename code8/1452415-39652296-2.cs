    public class Rootobject
    {
        public Fulfillment fulfillment { get; set; }
    }
    public class Fulfillment
    {
        public string tracking_number { get; set; }
        public Line_Items[] line_items { get; set; }
    }
    public class Line_Items
    {
        public string id { get; set; }
        public int quantity { get; set; }
    }
    public class JsonTest
    {
        public void Test()
        {
            var root = new Rootobject();
            root.fulfillment = new Fulfillment();
            root.fulfillment.tracking_number = "xxxx12222";
            root.fulfillment.line_items = new List<Line_Items>() { new Line_Items() { id = "1234566645", quantity = 1 } }.ToArray();
            var json = JsonConvert.SerializeObject(root);
            Console.WriteLine(json);
        }
    }
