    public class Tester
    {
        public class AssemblyLoggerControlModel
        {
            public static IScheduler S = AssemblyLoggerMCVE.Scheduler;
        }
        public class AssemblyLogger
        {
            public static AssemblyLoggerControlModel ModelInstance { get; } = 
                new AssemblyLoggerControlModel();
            public static readonly Lazy<Window> Window =
                new Lazy<Window>(NewWindowHandler);
            private static Window NewWindowHandler() => new Window();
            public static IScheduler Scheduler => 
                new DispatcherScheduler(Window.Value.Dispatcher);
        }
    
    }
