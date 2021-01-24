    public class Data
    {
        public string key { get; set; }
        public string label { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myString = @"
                    [{
                        'key': 182,
                        'label': 'testinstitution'
                    }]";
            List<Data> dict = new JavaScriptSerializer().Deserialize<List<Data>>(myString);
            foreach (var d in dict)
                Console.WriteLine(d.key + " " + d.label);
            Console.ReadKey();            
        }
    }
