    public class Foo
    {
        public int Id { get; private set; }
        public string Name;
    
        public Foo()
        {
            this.Id = 1; // This works!
        }
    }
