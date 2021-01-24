    public class Foo
    {
        public int Number { get; set; }
        private void DoSomething(int num)
        {
            Number += num;
        }
        private int DoSomething(int num)
        {
            // Bad example, but still valid.
            Number = num + 2;
            return num * num;
        }
    }
    var foo = new Foo();
    // Which version of the method do I want to call here?
    // Most likely it is the one that returns void,
    // but you can ignore the return type of any method call.
    foo.DoSomething(3);
