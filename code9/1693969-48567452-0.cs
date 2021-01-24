    public class ExampleClass
    {
        public class ExampleClass(string id)
        {
            _id = id;
        }
        //Fields
        private readonly string _id; //note the use of **readonly**
        public string Id { get {return _id; } } //So ExampleClassManager can see the id
    }
