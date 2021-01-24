    [KnownType(typeof(ChildClass1))]
    [KnownType(typeof(ChildClass2))]
    public class Widget
    {        
        public List<BaseClass> Contents { get; set; }
        public Widget()
        {
            Contents = new List<BaseClass>();
        }
    }
