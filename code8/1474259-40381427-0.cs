    public class EfNotesService : INotesService
    {
          public ExecuteSomeBusinessOperation(input parameters here)
          {
                // Validate input parameters
                using (PricedNotesContext ctxt = new PricedNotesContext())
                {
                    ctxt.Requests.Add(...);
                    ctxt.RequestData.Remove(...);
                    // other logic
                    ctxt.SaveChanges();
                }
          }
    }
