    public class Facade
    {
     private readonly ISystemA subsystemA;
     private readonly ISystemB subsystemB;
    
     public Facade(ISystemA subsystemA, ISystemB subsystemB)
     {
        this.subsystemA = subsystemA;
        this.subsystemB = subsystemB;
     }
     
     public void CreateAccount()
     {      
       this.subsystemA.CreateCreditCard();
       this.subsystemB.CheckCreditCard();
     }
    }
