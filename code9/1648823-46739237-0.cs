    public class EntityWrap<T>
    {
    	private Action<T> _realPrimaryCommand { get; set; }
    
    	public T Entity { get; set; }
    	public ICommand PrimaryCommand { get; set; }
    
    	public EntityWrap(T entity, Action<T> realPrimaryCommand)
    	{	
    		Entity = entity;
    		_realPrimaryCommand = realPrimaryCommand;
    		PrimaryCommand = new MvxCommand(() => _realPrimaryCommand(entity));
    	}
    }
