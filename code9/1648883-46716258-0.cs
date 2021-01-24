    namespace LinqKit
    {
    	public static class Extensions
    	{
    		public static bool Invoke<T>(this ExpressionStarter<T> expr, T arg)
    		{
    			return expr.Compile().Invoke(arg);
    		}
    	}
    }
