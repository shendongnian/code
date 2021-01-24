    public class Equipment
    {
        private int id;
        private string name;
    
        public Equipment (int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Identifier
        {
            get { return Id.ToString() + " " + Name; }
        }
    }
