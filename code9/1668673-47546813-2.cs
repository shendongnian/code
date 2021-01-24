    public class A
    {
        public virtual void DoSmth()
        {
        }
    }
    public class X : A
    {
        public override void DoSmth()
        {
        }
    }
    public class Y : A
    {
        public override void DoSmth()
        {
            
        }
    }
    public class Z : A
    {
        public override void DoSmth()
        {
            
        }
    }
    public class Example
    {
        public Example()
        {
            Types = new List<A>
            {
                new X(),
                new Y(),
                new Z()
            };
        }
        private List<A> Types { get; }
        public void DoAllTypes()
        {
            foreach (var type in Types)
            {
                type.DoSmth();
            }
        }
    }
