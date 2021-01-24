    public class RootObject
    {
        public One one { get; set; }
    }
    
    public class One
    {
        public List<Loja> two { get; set; }
    }
    
    public class Loja
    {
        public int cod { get; set; }
        public string nome { get; set; }
        public string phone { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
    }
