    public struct Customer
    {
        private int _id;
        private string _name;
    
        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
    
        public Customer(int Id, string Name)
        {
            _id=0;
            this._name = Name;
            this.Id = Id; // This will work now
        }
    }
