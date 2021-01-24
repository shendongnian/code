    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<Orders>();
            var records = engine.ReadFile("SampleCSV.csv");
            // Notice the change here. Only use dynamic if you *really* need it
            var dict = new Dictionary<String, Orders>();
            foreach (var record in records)
            {
               //either this:
               dict[record.Name] = record;
               //or this:
               dict.Add(record.Name, record);
               //(but not both!)
            }
        }
    }
