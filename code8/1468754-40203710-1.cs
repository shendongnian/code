    public class ClassB
    {
        private Action VariableA { get; set; }
        public void MethodB(ClassA classA)
        {
            VariableA = classA.MethodA;
        }
        public void MethodC()
        {
            VariableA();
        }
    }
