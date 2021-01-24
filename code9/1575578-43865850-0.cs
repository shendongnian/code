    public class CustomerValidation
    {
       public string propertyName {get;set;}
       public string validationRegex {get;set;}
       public string ValidationMessage {get;set;}
       public int ID {get;set;}
       public int CustomerId {get;set;}
       public virtual Customer CustomerInfo {get;set;}
    }
