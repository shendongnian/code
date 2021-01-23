    class Item
    {
        public string Filename { get; set; }
        public Info Info { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
    }
    
    class Info
    {
        public string Name { get; set; }
        public IList<string> Values { get; set; }
        public IList<string> NumericValues { get; set; }
        public IList<string> DateTimeValues { get; set; }
        public IList<string> LinkedComponentValues { get; set; }
        public int FieldType { get; set; }
    }
    
    class Description
    {
        public string Name { get; set; }
        public IList<string> Values { get; set; }
        public IList<string> NumericValues { get; set; }
        public IList<string> DateTimeValues { get; set; }
        public IList<string> LinkedComponentValues { get; set; }
        public int FieldType { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var description = new Description
            {
                Name = "description",
                Values = new List<string> { "This is description" },
                NumericValues = new List<string>(),
                DateTimeValues = new List<string>(),
                LinkedComponentValues = new List<string>(),
                FieldType = 0
            };
            var descriptionObj = JObject.FromObject(description);
    
            var item = new Item
            {
                Filename = "mypage.html",
                Info = new Info
                {
                    Name = "",
                    Values = new List<string>(),
                    NumericValues = new List<string>(),
                    DateTimeValues = new List<string>(),
                    LinkedComponentValues = new List<string>(),
                    FieldType = 0
                }
            };
            var itemObject = JObject.FromObject(item);
    
            itemObject.Add("description", descriptionObj);
            string json = itemObject.ToString();
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
