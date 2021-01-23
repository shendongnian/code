    public class NullAwaitable { }
    
    public static class Extensions
    {
    	public static TaskAwaiter GetAwaiter(this NullAwaitable _)
            => Task.CompletedTask.GetAwaiter();
    }
    
    public class MethodClass
    {
        public NullAwaitable Job() => new NullAwaitable();
    }
    
    MethodClass MyClass = null;
    
    await MyClass?.Job(); // works fine
