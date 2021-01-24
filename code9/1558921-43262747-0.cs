    public class Foo
    {
        public string Title {get;set;}
        public Foo(string title)
        {
            Title = title;
        }
        public Foo Copy()
        {
            Foo aCopy = new Foo(this.Title);
            return aCopy;
        }
    }
