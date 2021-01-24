    public class ChildObject
    {
        public string ChildObjectProperty1 {get; set;}
    }
    public class MainObject
    {
        public string Property1 {get; set;}
        public string Property2 {get; set;}
        public string Property3 {get; set;}
        public ChildObject Property4 {get; set;}
        public MainObject()
        {
            // Initialize Property4 to a new instance of a ChildObject
            this.Property4 = new ChildObject();
        }
    }
