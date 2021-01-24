    public class MyViewModel
    {
       public string Comment { set;get;}
       public List<ExceptionVm> PendingExceptions { set;get;}
       public MyViewModel()
       {
         PendingExceptions = new List<ExceptionVm>();
       }
    }
