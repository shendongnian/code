    class Program
    {
        static void Main(string[] args)
        {
            NameValueCollection col = new NameValueCollection();
            col.Add("A", "1");
            col.Add("A", "2");
            col.Add("B", "0");
            col.Add("B", "1");
            col.Add("B", "3");
            col.Add("D", "1");
            foreach (string key in col.AllKeys)
            {
                Console.WriteLine(key + " " + col[key] + "\n");
            }
            Console.ReadKey();
        }
    }
