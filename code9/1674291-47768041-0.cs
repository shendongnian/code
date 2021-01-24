    public class Foo
    {
        public Dictionary<string, object> Properties;
        public Foo()
        {
            Properties = new Dictionary<string, object>();
        }
    }
    public List<Foo> GetFoo()
    {
        var item = new Foo();
        item.Properties.Add("Name","Sample");
        item.Properties.Add("OtherName", "Sample");
        return new List<Foo>{ item };
    }
