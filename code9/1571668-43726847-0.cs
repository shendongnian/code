    public static void Test()
    {
        throw new Exception("Synchronous");
    }
    public static async void TestAsync()
    {
        await Task.Yield();
        throw new Exception("Asynchronous");
    }
    public class EventSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            if (state is ExceptionDispatchInfo
                && d.Target.GetType().ReflectedType.FullName == "System.Runtime.CompilerServices.AsyncMethodBuilderCore")
            {
                // Caught an exception
                var exceptionInfo = (ExceptionDispatchInfo)state;
                Console.WriteLine("Caught asynchronous exception: " + exceptionInfo.SourceException);
                return;
            }
            base.Post(d, state);
        }
    }
    static void Main(string[] args)
    {
        SomeEvent += TestAsync;
        SomeEvent += Test;
        var previousSynchronizationContext = SynchronizationContext.Current;
        try
        {
            SynchronizationContext.SetSynchronizationContext(new EventSynchronizationContext());
            SomeEvent();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught synchronous exception: " + ex);
        }
        finally
        {
            SynchronizationContext.SetSynchronizationContext(previousSynchronizationContext);
        }
        Console.ReadLine();
    }
