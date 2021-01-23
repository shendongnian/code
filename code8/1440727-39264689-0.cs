    class Program
    {
        static void Main(string[] args)
        {
            string IDS = "{\"IDS\":\"23,24,25,28\"}";
            var obj = JsonConvert.DeserializeObject<MyClass>(IDS);
            Console.WriteLine(obj.IDS);
            Console.ReadLine();
        }
    }
    class MyClass
    {
        public string IDS { get; set; }
    }
