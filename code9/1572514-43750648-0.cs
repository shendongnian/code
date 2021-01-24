     public class Request
    {
        .... Properties...
        public virtual ICollection<RequestAttribute> RequestAttributes { get; set; }
    }
    public class RequestAttribute
    {
        .... Properties...
        public virtual Request> Request { get; set; }
    }
