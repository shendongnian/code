    public interface IHasString
    {
        string aMember { get; }
    }
    public class Base
    {
        protected virtual IHasString aThing { get; set; }
        public Base(){}
       protected void doSomething()
        {
            Console.WriteLine(aThing.aMember);
        }
    }
    public class Deriv : Base
    {
       protected override IHasString aThing { get; set; }
       public void DoIt()
        {
            doSomething();
         }
    }
