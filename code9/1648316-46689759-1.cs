    public abstract class BaseValidator<T, E> : IValidator<T> 
    	where E: IEntity
    	where T: E
    {
       //some methods and parameters here
       protected void Include(IValidator<E> validator)
       {          
           //Some business logic around connecting validators
       }
    }
    public class BankAccountValidator : BaseValidator<BankAccount, OwnedProduct>
    {
    	public BankAccountValidator(IValidator<OwnedProduct> validator)
    	{
    		Include(validator);
    		//Some logic here
    	}
    }
    public class Program
    {
    	public static void Main()
    	{
    		var validator = new Validator<OwnedProduct>();				
    		var bankAccountValidator = new BankAccountValidator(validator);
    	}
    }
