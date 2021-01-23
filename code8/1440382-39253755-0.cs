    public class EmployeeBank
    {
            public int Id {get;set;}
            
            public Name {get;set;}
            
            public virtual EmployeePaymentMethod EmployeePaymentMethod { get; set; }
    }
    
    public class EmployeePaymentMethod
    {
            [Key, ForeignKey("EmployeeBank ")]
            public override int Id {get;set;}
            
            public virtual EmployeeBank EmployeeBank {get;set;}
    }
