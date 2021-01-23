    interface IStart
    {
        IMiddle A();
    }
    interface IMiddle
    {
        IFinal B();
    }
    interface IFinal
    {
        IFinal B();
        IFinal C();
        string DoSomething();
    }
    class Test : IStart, IMiddle, IFinal
    {
        public IMiddle A(string x = null) { return this; }
        public IFinal B(string x = null) { return this; }
        public IFinal C(string x = null) { return this; }
        public string DoSomethign { ... }
    }
