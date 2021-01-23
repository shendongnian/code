    public class Item
    {
        public Item() 
        { 
            _id = -1; 
        }
        public int Id 
        { 
            get 
            { 
                return _id; 
            }
            set
            {
                 if (_id != -1)
                 {
                     throw new OperationException("Item.Id has already been set");
                 }
                 _id = value;
            }
        }
        public string Name { get; set; }
    }
