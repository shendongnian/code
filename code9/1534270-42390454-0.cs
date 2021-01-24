    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public class CallbackArgs1
    	{
    		public CallbackArgs1(string text)
    		{
    			Text = text;
    		}
    		
    		public string Text { get; }
    	}
    	
    	public class CallbackArgs2
    	{
    		public CallbackArgs2(int number)
    		{
    			Number = number;
    		}
    		
    		public int Number { get; }
    	}
    	
    	public static void Main()
    	{
            // #1 You build a callback list with two sample callbacks
    		List<Delegate> callbacks = new List<Delegate>();
    		callbacks.Add(new Func<CallbackArgs1, int>(args => args.Text.Length));
    		callbacks.Add(new Func<CallbackArgs2, string>(args => args.Number.ToString()));
    		
            // This list will store each callback result
    		List<object> callbackResults = new List<object>();
    		
    		foreach(Delegate callback in callbacks)
    		{
                // #2 This gets first Func<T, TResult> generic argument
                // which is the argument class type
    			Type argsType = callback.GetType().GetGenericArguments()[0];
                // #3 Now it's about checking the arguments class type
                // and instantiate it 
    			object args;
    			
    			if(typeof(CallbackArgs1).IsAssignableFrom(argsType))
    			{
    				args = new CallbackArgs1("hello world");
    			}
    			else if(typeof(CallbackArgs2).IsAssignableFrom(argsType))
    			{
    				args = new CallbackArgs2(282);
    			}
    			else
    			{
    				throw new NotSupportedException();
    			}
    			
                // #4 Finally, the callback is dynamically called passing
                // the arguments class instance and the return value is 
                // stored in the callback result list.
    			callbackResults.Add(callback.DynamicInvoke(new [] { args }));
    		}
    		
    		
    		Console.WriteLine(string.Join(", ", callbackResults.Select(r => r.ToString())));
    	}
    }
