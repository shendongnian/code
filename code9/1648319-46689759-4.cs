    public class OwnedProductValidator : IValidator<OwnedProduct>
    { 
    	// IValidator interface implementation
    }
    public class Program
    {
    	public static void Main()
    	{
    		var ownedProductValidator = new OwnedProductValidator();				
    		var bankAccountValidator = new BankAccountValidator(ownedProductValidator);
    	}
    }
