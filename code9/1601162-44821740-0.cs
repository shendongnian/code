    public class Fruit
    {
        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Pip Pip
        {
            get { return this.pip; }
            set { this.pip = value; }
        }    
    }
