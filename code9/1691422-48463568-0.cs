    public class Foo
    {
    	public string Id {get; set;}
        public SomeProperty Name { get; set; }    
    
        public bool ShouldSerializeSomeProperty()
        {
            return SomeProperty != null || SomeProperty != "Tennis";
        }
    }
