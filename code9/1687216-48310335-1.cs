    public class Holder
    {
        private static Holder _instance;
        private Holder()
        {
            People = new List<Person>();
        }
        public static Holder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Holder();
                return _instance;
            }
        }
        public List<Person> People { get; set; }
    }
