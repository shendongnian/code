    public class Utente
    {
        private Utente(){} //override default public constructor.
        private static readonly Lazy<Utente> lazy =
        new Lazy<Utente>(() => new Utente());
    
        public static Utente Instance
        {
            get
            {
                return lazy.Value;
            }
            set
            {
    
            }
        }
    
        public string name { get; set; }
        public string lastname { get; set; }
        public int id { get; set; }
        public int issuperuser { get; set; }
        public string persontype { get; set; }
        public int idpersontype { get; set; }
        public string token { get; set; }
        public string[] permissions { get; set; }
        public List<Mese> mese { get; set; }
    }
