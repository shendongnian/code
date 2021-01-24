    public class MyJobFactory : IJobFactory
    {
    	public IJob GetJobInstance<T>() where T : IJob
        {
            return MyContainer.GetJobInstance<T>();
        }
    }
