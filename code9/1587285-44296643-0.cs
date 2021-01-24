    public class ThirdParty
    {
    	private struct MsgType { }
    	private static void AnotherFunc(MsgType msg) { Console.WriteLine($"HEY: {msg}"); }
    }
    
    public class AnotherThirdParty
    {
    	public static void CallEvent<T>(Func<int,Action<T>> action, T arg)
    	{
    		action(12)(arg);
    	}
    }
    
    public static void Main()
    {
    	var msgTypeType = typeof(ThirdParty).GetNestedType("MsgType", BindingFlags.NonPublic);
    	var ourMsgTypeArg = Activator.CreateInstance(msgTypeType);
    	
    	var callEventMethod = 
    		typeof(AnotherThirdParty).GetMethod("CallEvent", BindingFlags.Public | BindingFlags.Static)
    		.MakeGenericMethod(msgTypeType);
    		
    	var anotherFunc = 
    		typeof(ThirdParty).GetMethod("AnotherFunc", BindingFlags.NonPublic | BindingFlags.Static);
    
    	var func = CreateFunc(msgTypeType, anotherFunc);
    	callEventMethod.Invoke(null, new object[] {
    		func,
    		ourMsgTypeArg
    	}).Dump();
    }
    
    private static Delegate CreateFunc(Type msgType, MethodInfo anotherFunc)
    {
    	var intArg = Expression.Parameter(typeof(int));
    	var msgTypeArg = Expression.Parameter(msgType);
    	
    	var call = Expression.Call(null, anotherFunc, msgTypeArg);
    	
    	var action = Expression.Lambda(call, msgTypeArg);
    	var func = Expression.Lambda(action, intArg);
    	return func.Compile();
    }
