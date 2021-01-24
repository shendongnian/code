    public class ActionService : IActionService 
    {
       public IRepositoryA repA {get;set;}
       public IRepositoryB repB { get;set;}
       public ActionService (IRepositoryA rep_a , IRepositoryB rep_b ) {
          repA = rep_a;
          repB = rep_b;
       }
       
       DoTaskX(){
        // do task using repository A and B
       }
    }
