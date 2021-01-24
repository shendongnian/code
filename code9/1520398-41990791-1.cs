    public abstract class BaseController : Controller
    {
        protected StandardJsonResult JsonValidationError()
        {
            var result = new StandardJsonResult();
    
            foreach (var validationError in ModelState.Values.SelectMany(v => v.Errors))
            {
                result.AddError(validationError.ErrorMessage);
            }
            return result;
        }
    
        protected StandardJsonResult JsonError(string errorMessage)
        {
            var result = new StandardJsonResult();
    
            result.AddError(errorMessage);
    
            return result;
        }
    
        protected StandardJsonResult<T> JsonSuccess<T>(T data)
        {
            return new StandardJsonResult<T> { Data = data };
        }
    }
