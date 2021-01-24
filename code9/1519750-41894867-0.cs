    public class CodeGenerator
    {
        public delegate void GeneratorCalculatorEventHandler(decimal Fond);
        public event GeneratorCalculatorEventHandler eventName;
        public CodeGenerator(GeneratorCalculatorEventHandler listener)
        {
            eventName += listener;
            eventName?.Invoke(0);
        }
    }
    public class Test
    {
        public Test()
        {
            CodeGenerator gen = new CodeGenerator((sen) => { return; });
        }
    }
