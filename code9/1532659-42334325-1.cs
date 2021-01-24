    public class PaymentViewModel {
    
        // other properties ...
        public string approved { get; set; }
        public bool IsApproved {get {return this.approved == "1" }}
    }
