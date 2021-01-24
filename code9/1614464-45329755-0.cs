    public abstract class AbstractBaseClass
    {
        public AbstractBaseClass()
        {
            ObjectRegister.StoreReference(this);
        }
    
        public abstract void MethodToCall();
    }
    public class SubClass : AbstractBaseClass
    {
        public SubClass() : base() //Don't forget 'base()'!
        {
            //Your code here
        }
        public override void MethodToCall()
        {
            Console.WriteLine("Called in SubClass");
        }
    }
