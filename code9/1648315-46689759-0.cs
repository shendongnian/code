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
