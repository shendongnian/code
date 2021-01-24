    public class Base
    {
        private Thing aThing;
        public Base() { }
    
        protected virtual void doSomething()
        {
            System.Console.WriteLine(aThing.aMmebr);
        }
    }
    
    
    public class Deriv : Base
    {
        private AnotherThing anotherThing;
    
        protected override void doSomething()
        {
            System.Console.WriteLine(anotherThing.aMmebr);
        }
        public void DoIt()
        {
            doSomething();
        }
    }
