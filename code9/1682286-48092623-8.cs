    public interface ICommunicationLoggService
    {
      [OperationContract]
      bool SaveLog(Loggable loggable);
    }
    
    public class Loggable {
        
    }
    
    public class Employee : Loggable {
        
    }
    
    public class Studend : Loggable {
        
    }
    
    public class Address : Loggable {
        
    }
