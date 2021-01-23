    public class TestObject : IObject {
       
        private string name;
    
        public string Name { get{return name;}set{name = value;}}
    
        public TestObject (string name) {
            Name = name;
        }
    }
