    public class Rootobject
    {
        public Fulfillment fulfillment { get; set; }
    }
    public class Fulfillment
    {
        public int id { get; set; }
        public string status { get; set; }
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
            Fulfillment product = new Fulfillment();
            product.status = "success";
            product.tracking_number = "xxxx12222";
            product.line_items = new List<Line_Items>() { new Line_Items() { id = "1234566645", quantity = 1 } }.ToArray();
            var json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);
        }
    }
