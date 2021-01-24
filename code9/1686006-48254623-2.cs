    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
    	public async Task Init(string parameter)
    	{
    		if (!string.IsNullOrEmpty(parameter))
    		{
    			IMvxJsonConverter serializer;
    			if (!Mvx.TryResolve(out serializer))
    			{
    				throw new MvxIoCResolveException("There is no implementation of IMvxJsonConverter registered. You need to use the MvvmCross Json plugin or create your own implementation of IMvxJsonConverter.");
    			}
    
    			var deserialized = serializer.DeserializeObject<TParameter>(parameter);
    			Prepare(deserialized);
    			await Initialize();
    		}
    	}
    
    	public abstract void Prepare(TParameter parameter);
    }
