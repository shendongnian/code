    public class Base
    {
        protected virtual string aThing { get { return "base"; } }
        public Base(){}
       protected void doSomething()
        {
            Console.WriteLine(aThing);
        }
    }
    public class Deriv : Base
    {
       protected override string aThing { get { return "child";} }
       public void DoIt()
        {
            doSomething();
         }
    }
