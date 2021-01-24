    public class Mix
    {
        public MainObjet obj { get; set; }
        public IEnumerable<Numbers> num { get; set; }
        public Mix()
        {
            obj = new MainObjet();
            num = new List<Numbers>();
        }
    }
