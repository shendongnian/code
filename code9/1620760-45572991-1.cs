    public Action Foo()
    {
        CompiledGeneratedClass tmp = new CompilerGEneratedClass();
        tmp.test = new Test();
        Action printB = tmp.GeneratedMethod;
        return printB;
    }
    private class CompilerGeneratedClass
    {
        public Test test;
        public void GeneratedMethod()
        {
            Console.WriteLine(test.b)
        }
    }
