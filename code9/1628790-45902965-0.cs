    abstract class Base<TSelf>
    {
        // Let's make it a property rather than a public field...
        public ICollection<TSelf> List { get; }
    
        public Base()
        {
            List = new List<TSelf>();
            // This will obviously fail if you try to create a `Base<Foo>`
            // from a class that isn't a Foo
            TSelf selfThis = (TSelf) (object) this;
            List.Add(selfThis);
        }
    }
    
    class Implementation : Base<Implementation>
    {
    }
