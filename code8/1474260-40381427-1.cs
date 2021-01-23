    public class EfNotesService : INotesService
    {
          private readonly PricedNotesContext _ctxt;
          public EfNotesService(PricedNotesContext ctxt )
          {
              _ctxt = ctxt;
          }
          public ExecuteSomeBusinessOperation(input parameters here)
          {
                // Validate input parameters
                
                _ctxt .Requests.Add(...);
                _ctxt .RequestData.Remove(...);
                // other logic
                _ctxt .SaveChanges();               
          }
    }
