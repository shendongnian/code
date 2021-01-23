    public static class FuncHelper
    {
	    public static async Task RunSequential<T1>(this Func<T1,Task> del, T1 param1)
    	{		
		    foreach (var d in del.GetInvocationList().OfType<Func<T1, Task>>())
		    {
			    await d(param1);
            }
	    }
	    public static async Task RunSequential<T1, T2>(this Func<T1, T2, Task> del, T1 param1, T2 param2)
	    {
		    foreach (var d in del.GetInvocationList().OfType<Func<T1, T2, Task>>())
		    {
			    await d(param1, param2);
		    }
	    }
    // Additional methods for more parameters go here
    }
