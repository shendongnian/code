    public class Compra
        {
            public Compra()
            {
                ComboList = new List<Combo>();
            }
            public string ID { set; get; }
            public List<Combo> ComboList { set; get; }
        }
    
        public class Combo
        {
            public string ID { set; get; }
            public string NAME { set; get; }
        }
