    public class Sorular
    {
        public string soru1 { get; set; }
        public string soru2 { get; set; }
    }
    
    public class RootObject
    {
        public string baslik { get; set; }
        public List<Sorular> sorular { get; set; }
    }
