	protected TContext Context { get; private set; } // <--(4) context = null
	protected RepositoryBase(TContext context) // <--(2) context = null
	{
		this.Context = context; // <--(3) context = null
	}
