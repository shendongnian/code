    static void Main(string[] args)
    {
        var values = JsonConvert.DeserializeObject<RootObject>(json);
        var dictionary = values.Schlagwort.ToDictionary(x => x.Name, y => y.Wert);
    }
    public class Informationen
    {
        public string Name { get; set; }
        public string Wert { get; set; }
    }
    public class RootObject
    {
        public string Schlagwortmaskname { get; set; }
        public IList<Informationen> Schlagwort { get; set; }
    }
