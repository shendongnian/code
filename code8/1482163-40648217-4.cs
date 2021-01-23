    public interface IEmployee
    {
    }
    
    public interface IClerk : IEmployee
    {
      void DoClerkThing();
    }
    
    public interface IManager : IEmployee
    {
       void DoManagerThing();
    }
    public class Clerk : IClerk
    {
      public void DoClerkThing()
      {
      }
    }
    public class Manager : IManager
    {
       public void DoManagerThing()
       {
       }
    }
    
    public class ManagerAndClerk : IManager, IClerk
    {
      private readonly Manager manager;
      private readonly Clerk clerk;
      public ManagerAndClerk(Manager manager, Clerk clerk)
      {
        this.manager = manager;
        this.clerk = clerk;
      }
      public void DoClerkThing()
      {
        this.clerk.DoClerkThing();
      }
      public void DoManagerThing()
      {
        this.manager.DoManagerThing();
      }
    }
