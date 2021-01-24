    public static class Controller
    {
    	public static Controller<TEntity, TEntity> Create<TEntity>()
    	{
    		return new Controller<TEntity, TEntity>(new IdentityTransformer<TEntity>());
    	}
    }
