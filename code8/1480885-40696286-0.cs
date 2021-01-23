    using System.Data;
    using System.Data.Common;
    using System.Data.Entity.Infrastructure.Interception;
    public static class Sp
    {
    	public const string CallPrefix = "CallSP ";
    
    	public static string Call(string name) { return CallPrefix + name; }
    
    	public class CallInterceptor : DbCommandInterceptor
    	{
    		public static void Install()
    		{
    			DbInterception.Remove(Instance);
    			DbInterception.Add(Instance);
    		}
    
    		public static readonly CallInterceptor Instance = new CallInterceptor();
    
    		private CallInterceptor() { }
    
    		static void Process(DbCommand command)
    		{
    			if (command.CommandType == CommandType.Text && command.CommandText.StartsWith(Sp.CallPrefix))
    			{
    				command.CommandText = command.CommandText.Substring(Sp.CallPrefix.Length);
    				command.CommandType = CommandType.StoredProcedure;
    			}
    		}
    
    		public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    		{
    			Process(command);
    			base.ReaderExecuting(command, interceptionContext);
    		}
    	}
    }
