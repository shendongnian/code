    public class Sample
    {
        public string Userid { get; set; }
        public string Id { get; set; }
    }
    public static void Main(string[] args)
    {
            using (var stream = new StreamReader("sample.json"))
            {
                var sampleArray = JsonConvert.DeserializeObject<Sample[]>(stream.ReadToEnd());
                foreach (var users in sampleArray)
                {
                    Console.WriteLine("Userid: {0}", users.Userid);
                    Console.WriteLine("Id: {0}", users.Id);
                }
            }
            Console.Read();
    }
