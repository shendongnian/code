    public class ThirdParty
    {
    	private struct MsgType { }
    	private static void AnotherFunc(MsgType msg)
    	{
    		// Inserted to demonstrate getting here
    		Console.WriteLine($"HEY: {msg}");
    	}
    }
    
    public class AnotherThirdParty
    {
    	public static void CallEvent<T>(Func<int, Action<T>> action, T arg)
    	{
    		// Inserted to demonstrate calling the func and then
    		// the action
    		action(12)(arg);
    	}
    }
    
    public static void Main()
    {
    	var msgTypeType = 
    		typeof(ThirdParty).GetNestedType("MsgType", BindingFlags.NonPublic);
    	
    	// This is the message type we're passing (presumably you'll do more with it)
    	var ourMsgTypeArg = Activator.CreateInstance(msgTypeType);
    
    	// Get the reference to the CallEvent method
    	var callEventMethod =
    		typeof(AnotherThirdParty).GetMethod("CallEvent", BindingFlags.Public | BindingFlags.Static)
    		.MakeGenericMethod(msgTypeType);
    
    	// Get the reference to the AnotherFunc method
    	var anotherFunc =
    		typeof(ThirdParty).GetMethod("AnotherFunc", BindingFlags.NonPublic | BindingFlags.Static);
    
    	// Build the func to pass along to CallEvent
    	var func = CreateFunc(msgTypeType, anotherFunc);
    	
    	// Call the CallEvent<MsgType> method.
    	callEventMethod.Invoke(null, new object[] {
    		func,
    		ourMsgTypeArg
    	});
    }
    
    private static Delegate CreateFunc(Type msgType, MethodInfo anotherFunc)
    {
    	// The func takes an int
    	var intArg = Expression.Parameter(typeof(int));
    	
    	// The action takes a msgType
    	var msgTypeArg = Expression.Parameter(msgType);
    
    	// Represent the call out to "AnotherFunc"
    	var call = Expression.Call(null, anotherFunc, msgTypeArg);
    
    	// Build the action to just make the call to "AnotherFunc"
    	var action = Expression.Lambda(call, msgTypeArg);
    	
    	// Build the func to just return the action
    	var func = Expression.Lambda(action, intArg);
    	
    	// Compile the chain and send it out
    	return func.Compile();
    }
