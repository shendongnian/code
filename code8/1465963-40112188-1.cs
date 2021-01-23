    public class DefaultProcessor : IDefaultProcessor
    {
         public void Process(IProcess p)
         {
             DoProcess(p);
         }
         public TResult Process<TResult>(IProcess p)
         {
             object result = DoProcess(p);
             return (TResult)result;
         }
         private object DoProcess(IProcess p)
         {
             try
             {
                 foreach ...
                 return p.Result();
             }
             catch(Exception ex)
             {
                  Console.WriteLine(ex.Message);
                  throw;
             }
         }
    }
