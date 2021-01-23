    public interface IEmployee
    {
    }
    
    public interface IClerk : IEmployee
    {
    }
    
    public interface IManager : IEmployee
    {
    }
    
    public class Employee : IEmployee
    {
    }
    public class Clerk : IClerk
    {
    }
    public class Manager : IManager
    {
    }
    
    public class ManagerAndClerk : IManager, IClerk
    {
    }
