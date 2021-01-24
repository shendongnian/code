    public class ApplicationContext
    {
    	public static T Resolve<T>() where T: class 
        {
            return container.GetInstance<T>();
        }
    }
