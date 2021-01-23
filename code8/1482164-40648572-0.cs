    public abstract class ManagerBase
    {
        public void Execute()
        {
            Manage();
        }
        public virtual void Manage() {}
    }
    public abstract class ClerkBase
    {
        public virtual void Expedite(){}
        public void Execute()
        {
            Expedite();
        }
    }
    public class ManagingClerk : ClerkBase, ManagerBase
    {
        public override void Expedite()
        {
            Console.WriteLine("Expedited");
        }
        public override Manage()
        {
            Console.WriteLine("Managed");
        }
    }
