    public interface IRService
    {
       int GetRDataCount(int pId);
    }
    public class RService : IRService
    {
       private RrContext _rrContext;     
       public RService (RrContext rrContext)
       {
          this._rrContext=rrContext;
       }  
       public int GetRDataCount(int pId)
       {
         return _rrContext.RrData.Count(x => x.Pid == pId);
       }
    } 
