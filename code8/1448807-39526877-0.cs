    For containment object fluentvalidation doesn't work as you have implemented.
    
    For this refer complex properties validation from fluent validation and try with below code.
    
    [Validator(typeof(ClientValidator))]
    public class Client
    {
        public string CompanyName{get;set;}
        private volatile Contact Shipping = null;
        private volatile Contact Billing = null;
    }
    
    public class Contact : Address
    {
    
    }
    
    public class Address
    {
    	public String Name{get;set;}
    	public String Phone{get;set;}
    }
    
    public class AddressValidator : AbstractValidator<Address>
    {
        public ClientValidator()
    	{
    		RuleFor(x => x.Name).NotNull().WithMessage("Required").Length(1, 15).WithMessage("Length issue.");
    		RuleFor(x => x.Phone).NotNull().WithMessage("Required").Length(1, 15).WithMessage("Length issue.");
    	}
    } 
    
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
    	{
    		RuleFor(x => x.CompanyName).NotNull().WithMessage("Required").Length(1, 15).WithMessage("Length issue.");
    		RuleFor(x => x.Shipping).SetValidator(new AddressValidator());
            RuleFor(x => x.Billing).SetValidator(new AddressValidator());
        }
    }
    
    
      
