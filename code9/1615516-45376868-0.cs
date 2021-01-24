    public interface ICalculator
    {
        bool Quack { get; }
    }
    [Export(typeof(ICalculator))]
    public class MySimpleCalculator : ICalculator
    {
        public bool Quack => true;
    }
    [Export]
    public class MyMainClass
    {
        public ICalculator Calculator { get; }
        public string Blah { get; }
        [ImportingConstructor]
        public MyMainClass(ICalculator calculator)
        {
            Calculator = calculator; // assign readonly property
            Blah = calculator.Quack ? "Foo" : "Bar"; // do something based on calculator
        }
    }
