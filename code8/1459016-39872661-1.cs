    public class TestObject : IObject {
       
        private string _name;
    
        public string Name { 
            get { return _name; }
            set { _name = value; }
        }
    
        public TestObject (string name) {
            Name = _name;
        }
    }
