    using System;
	using System.Reflection;
	using Ninject;
	using log4net;
	namespace SomeNameSpace
	{
		public class MyProgram
		{
            private static ILog _log;
			public static void Main(string[] args)
			{
				try
				{
					Initialiase();
					_log.Info("Application - Start");
					_something.DoSomething();
					_log.Info("Application - End");
				}
				catch (Exception ex)
				{
					_log.Error("Application failed", ex);
				}
			}
			private static void Initialiase()
			{
				var kernel = new StandardKernel();
				kernel.Load(Assembly.GetExecutingAssembly());
			    _log = kernel.Get<ILog>();
				_something = kernel.Get<ISomething>();
		    }
        }
		
	    public class Bindings : NinjectModule
		{
			public override void Load()
			{
                Bind<ILog>().ToMethod(c => LogManager.GetLogger(typeof(Program))).InSingletonScope();
				Bind<ISomething>().To<Something>();
			}
		}
	}
