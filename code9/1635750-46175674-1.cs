    public class A
    {
        public virtual string Hello { get { return "HelloA"; } }
    }
    
    public class B : A
    {
        public override string Hello { get { return "HelloB"; } }
    }
