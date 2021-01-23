    public class Bar
    {
        public Bar(int value)
        {
            Value = value;
        }
        [Validate]
        public int Value { get; }
    }
    public class Foo
    {
        public Foo(string someString, ArgumentException someArgumentExcpetion, Exception someException, object someObject, Bar someBar)
        {
            SomeString = someString;
            SomeArgumentException = someArgumentExcpetion;
            SomeException = someException;
            SomeObject = someObject;
            SomeBar = someBar;
        }
        [Validate]
        public string SomeString { get; }
        [Validate]
        public ArgumentException SomeArgumentException { get; }
        [Validate]
        public Exception SomeException { get; }
        [Validate]
        public object SomeObject { get; }
        [Validate]
        public Bar SomeBar { get; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var someObject = new object();
            var someArgumentException = new ArgumentException();
            var someException = new Exception();
            var foo = new Foo("", someArgumentException, someException, someObject, new Bar(-1));
            var validator = new Validator<Foo>();
            var bag = new List<string>();
            validator.RegisterRule<string>(s => !string.IsNullOrWhiteSpace(s));
            validator.RegisterRule<Exception>(exc => exc == someException);
            validator.RegisterRule<object>(obj => obj == someObject);
            validator.RegisterRule<Bar>(b => { var barValidator = new Validator<Bar>();
                                               barValidator.RegisterRule<int>(l => l > 0);
                                               return barValidator.Validate(b, bag); });
            var valid = validator.Validate(foo, bag);
        }
    }
