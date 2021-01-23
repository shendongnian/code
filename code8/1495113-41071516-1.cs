    using System;
    using System.Reflection;
    					
    public class Program
    {
    	public static void Main()
    	{	    		
    		var instance = new Test<string, string, string, string, string>();
    		instance.DoIt();
    	}   	
    }
    
    public class Test<T, T1, T2, T3, T4>
    {    	
    	public void DoItAgain<T5>()
    	{
    		Console.WriteLine(typeof(T5));
    	}
    	
        public void DoIt()
        {    		
    		Type[] genericTypes = this.GetType().GetGenericArguments();
            foreach (var TItem in genericTypes)
            {    			
    			Console.WriteLine(TItem);	
    			
    			//Instead of 
    			// var foo = SomeService.Get<TItem>();
    			
    			//Call generic method like this
    			MethodInfo method = this.GetType().GetMethod("DoItAgain");
    			MethodInfo generic = method.MakeGenericMethod(TItem);
    			generic.Invoke(this, null);      						
            }						
        }
    }
