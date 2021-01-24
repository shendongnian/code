    public class GlobalMessage
    {
       public string Message { get;set;}
       public AlertType AlertType {get;set;}
    }
    public enum AlertType
    {
       Success, Info, Error, Danger//etc
    }
