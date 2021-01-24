    public static void Main(string[] args)
    {
            using (var stream = new StreamReader("sample.json"))
            {
                var sample = JsonConvert.DeserializeObject<Root>(stream.ReadToEnd());
                Console.WriteLine(sample.Product.col1);
                Console.WriteLine(sample.Product.col2);
                foreach (var t in sample.Samples)
                {
                    Console.WriteLine(t.col3);
                    Console.WriteLine(t.col4);
                }
            }
            Console.Read();
    }
