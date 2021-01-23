    public class DataRepositoryFactory<T> where T : IDataRepository
    {
    	private Type dataRepositoryImplementationType;
    
    	public DataRepositoryFactory(T dataRepositoryImplementation)
    	{
    		if (dataRepositoryImplementation == null)
    		{
    			throw new ArgumentException("dataRepositoryImplementation");
    		}
    
    		this.dataRepositoryImplementationType = dataRepositoryImplementation.GetType();
    	}
    
    	public T Create()
    	{
    		return (T)Activator.CreateInstance(this.dataRepositoryImplementationType);
    	}
    }
    
