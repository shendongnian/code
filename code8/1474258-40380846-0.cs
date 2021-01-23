    public class EfNotesService : INotesService
    {
        private readonly PricedNotesContext _ctxt = new PricedNotesContext();
        public IEnumerable<Request> GetAllRequests()
        {
            return _ctxt.Requests.ToList();
        }
        public void SaveRequest(Request request)
        {
            _ctxt.Entry(request).State = EntityState.Modified;
        }
        public void DeleteRequestData(BaseRequestData reqData)
        {
            _ctxt.RequestData.Remove(reqData);
        }
        // ...
        // Other methods...
        // ...
        // Transaction control
        public void SaveChanges()
        {
            _ctxt.SaveChanges();
        }
        public void Dispose()
        {
            _ctxt.Dispose();
        }
    }
