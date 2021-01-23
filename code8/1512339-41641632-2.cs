    class Visitor
    {
        public void Visit(ClassA obj){ obj.M1(); } // Here you have to know what method will be called!
        public void Visit(ClassB obj){ obj.M2(); } // Here you have to know what method will be called!
    }
    abstract class Visitable
    {
        public abstract void Accept(Visitor visitor);
    }
