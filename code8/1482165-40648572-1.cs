    public interface IManager
    {
        void Execute();
        void Manage();
    }
    public interface IClerk
    {
        void Expedite();
        void Execute();
    }
    public class ManagingClerk : IClerk, IManager
    {
        public void Expedite()
        {
            Console.WriteLine("Expedited");
        }
        void IClerk.Execute()
        {
            Expedite();
        }
        public void Manage()
        {
            Console.WriteLine("Managed");
        }
        void IManager.Execute()
        {
            Manage();
        }
    }
