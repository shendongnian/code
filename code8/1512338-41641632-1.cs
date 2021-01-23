    class ClassA : Visitable
    {
        public void M1(){}
        public override void Accept(Visitor visitor){visitor.Visit(this)}
    }
    class ClassB : Visitable
    {
        public void M2(){}
        public override void Accept(Visitor visitor){visitor.Visit(this)}
    }
