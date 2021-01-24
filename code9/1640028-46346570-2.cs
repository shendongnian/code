    public class Dto
    {
        private List<string> Changed = new List<string>();
        public bool IsChanged(string field) => Changed.Contains(field);
        private int _age;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // IMPORTANT: field name should fit main object field name
                Changed.Add("Name"); 
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Changed.Add("Age");
            }
        }
    }
