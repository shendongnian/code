    public class Request 
    {
        public RequestStatus CurrentStatus {get; set;}
        
        public RequestMomento SaveStateToMomento()
        {
            return new RequestMomento(CurrentStatus);
        }
        public void GetStateFromMomento(RequestMomento momento)
        {
            CurrentStatus = momento.GetStatus();
        }
    }
