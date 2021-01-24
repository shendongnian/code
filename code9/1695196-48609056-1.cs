    public class YourClass
    {
    	public dynamic DialogWithResult<TViewModel>(object owner = null)
    	{
    		//	Searching for DialogResultBase<TSomeReturnType> in bases classes of TViewModel
    		Type currType = typeof(TViewModel);
    		while (currType != null && currType != typeof(DialogResultBase<>))
    		{
    			if (currType.IsGenericType && currType.GetGenericTypeDefinition() == typeof(DialogResultBase<>))
    			{
    				break;
    			}
    
    			currType = currType.BaseType;
    		}
    		if (currType == null)
    		{
    			throw new InvalidOperationException($"{typeof(TViewModel)} does not derive from {typeof(DialogResultBase<>)}");
    		}
    
    		Type returnValueType = currType.GetGenericArguments()[0];
    
    		//	Now we know TViewModel and TSomeReturnType and can call DialogWithResult<TViewModel, TSomeReturnType>() via reflection.
    		MethodInfo genericMethod = GetType().GetMethod(nameof(DialogWithResultGeneric));
    		if (genericMethod == null)
    		{
    			throw new InvalidOperationException($"Failed to find {nameof(DialogWithResultGeneric)} method");
    		}
    
    		MethodInfo methodForCall = genericMethod.MakeGenericMethod(typeof(TViewModel), returnValueType);
    		return methodForCall.Invoke(this, new [] { owner } );
    	}
    
    	public IDialogWithResult<TViewModel, TSomeReturnType> DialogWithResultGeneric<TViewModel, TSomeReturnType>(object owner = null)
    		where TViewModel : DialogResultBase<TSomeReturnType>
    	{
    		// ...
    	}
    }
