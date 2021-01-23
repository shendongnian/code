    public class Program
    {
        public static void Main(string[] args)
        {
            MethodInfo handler = typeof(Program).GetMethod("GlobalEventHandler");
            IEnumerable<EventInfo> events = AppDomain.CurrentDomain
                .GetAssemblies()
                .Select(a => a.GetTypes()
                              .Select(t => t.GetEvents(
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Static)
                                             .Where(e => typeof(EventHandler)
                                                         .IsAssignableFrom(e.EventHandlerType))))
                .SelectMany(e => e)
                .SelectMany(e => e);
            foreach (EventInfo evt in events)
                evt.GetAddMethod(true).Invoke(null, new object[]
                {
                    Delegate.CreateDelegate(evt.EventHandlerType, null, handler)
                });
        }
  
        public static void GlobalEventHandler(object sender, EventArgs args)
        {
            Debugger.Break(); <-- When a static event is fired, the application will break
            Console.WriteLine("An event was fired!");
        }
