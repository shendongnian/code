    class Fruits
    {
    
        string fruit { get; set; }
        int amount { get; set; }
    
        public Fruits(string a, int b)
        {
            fruit = a;
            amount = b;
        }
    
        public override string ToString()
        {
            return string.Format("Fruit: {0} Ammount: {1}", fruit, amount);
        }
    }
