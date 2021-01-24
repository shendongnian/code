    public class AValidator : IValidator<A>
    {
        IEnumerable<ValidationError> Validate(A obj)
        {
            if(obj.b == null)
                yield return new ValidationError {Message = "b is null", PropertyPath = "a.b"};
            else
            { 
                var bresults = new BValidator().Validate(obj.b);
                foreach(var result in bresults)
                {
                    result.PropertyPath = "a.b." + result.PropertyPath;
                    yield return result;
                }
            }
    ...
                var cresults = new BValidator().Validate(obj.c[i]);
                foreach(var result in cresults)
                {
                    result.PropertyPath = "a.c[i]." + result.PropertyPath;
                    yield return result;
                }
        }        
    }
