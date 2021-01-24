    internal class Program
    {
        private static void Main(string[] args)
        {
            var file = new StreamReader(@"C:\test\csvTest.csv");
            string line;
            List<Item> items = new List<Item>();
            while ((line = file.ReadLine()) != null)
            {
                var fields = line.Split(',');
                
                items.Add(
                    new Item
                    {
                        UserId = fields[0],
                        Thing1ID = fields[1],
                        Thing1name = fields[2],
                        Thing1value = fields[3],
                        Thing2ID = fields[4],
                        Thing2name = fields[5],
                        Thing2value = fields[6],
                        Thing3ID = fields[7],
                        Thing3name = fields[8],
                        Thing3value = fields[9]
                    });
            }
            string json = JsonConvert.SerializeObject(items);
            Console.WriteLine(json);
        }
    }
    public class Item
    {
        public string UserId { get; set; }
        public string Thing1ID { get; set; }
        public string Thing1name { get; set; }
        public string Thing1value { get; set; }
        public string Thing2ID { get; set; }
        public string Thing2name { get; set; }
        public string Thing2value { get; set; }
        public string Thing3ID { get; set; }
        public string Thing3name { get; set; }
        public string Thing3value { get; set; }
    }
