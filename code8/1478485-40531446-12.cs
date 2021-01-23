    public abstract class DealerBase
    {
        public string Name { get; }
        
        public decimal Price { get; set; }
        protected DealerBase(string name)
        {
            Name = name;
        }  
        public abstract void UpdatePrice();   
    }
