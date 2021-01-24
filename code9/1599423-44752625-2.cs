        [Application(Icon="@drawable/icon", Label="@string/app_name")]
    	public class App : Application
    	{
    		public static IContainer Container { get; set; }
    
    		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
    		{
    		}
    
    		public override void OnCreate()
    		{
    			var builder = new ContainerBuilder();
                builder.RegisterInstance(new MyContextUtility()).As<IContextUtility>();
                ...
    		}
    	}
