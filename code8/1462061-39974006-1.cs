    public class A
    {
        public virtual void methodA()
        {
        }
    }
    public class B : A
    {
        public void methodB()
        {
            var ClassA = new A();
        }
        public override void methodA()
        {
            //Do stuff
        }
    }
