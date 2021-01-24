    public class Product
        {
            public ObservableCollection<Crystal> Crystals { set; get; }
            public String ChipName { set; get; }
            public Product(ObservableCollection<Crystal> l, String ChipName)
            {
                this.ChipName = ChipName;
                Crystals = l;
            }
        }
    
        public class Crystal
        {
            public string Value { set; get; }
        }
