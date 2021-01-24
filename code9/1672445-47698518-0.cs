    public class MustHaveMoreThanOneItemAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) 
        {
            var enumerable = value as IEnumerable;
    		var enumerator = enumerable.GetEnumerator();
    		if (!enumerator.MoveNext())
    		{
    			return false;
    		}
    	
    		if (!enumerator.MoveNext())
    		{
    			return false;
    		}
    		
    		return true;
        }
    }
