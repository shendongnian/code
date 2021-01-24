    public abstract class BusinessBase<TEntity> where TEntity : IEntity
	{
	    private Repository<TEntity> _repository { get; set; }
	
	    public BusinessBase()
	    {
	        var myClass = typeof(TEntity);
	        var myClassName = myClass.Name; // "Person" as expected
	
	        this._repository = new Repository<TEntity>();
	    }
	}
