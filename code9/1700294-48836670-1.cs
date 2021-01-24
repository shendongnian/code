	internal sealed class EchoProcess : MainData
	{
		private EchoProcess()
		{
		}
	
		public static string GetPrivateFromMainData()
		{
			return MainData.GetStorePrivateData<EchoProcess, Key>();
		}
	
		private class Key
		{
	
		}
	}
	
	internal class MainData
	{
		protected MainData()
		{
		}
	
		private static readonly List<string> StorePrivateData = new List<string>();
	
		public static string GetStorePrivateData<TEcho, TKey>() where TEcho : class where TKey : class
		{
			return CheckAllowGetStorePrivateDataClassAccess<TEcho, TKey>() ? "Allowed" : "Blocked";
		}
	
		private static bool CheckAllowGetStorePrivateDataClassAccess<TEcho, TKey>()
		{
			var trace = new StackTrace();
			var callingFrame = trace.GetFrame(2);
			var callingClass = callingFrame.GetMethod().DeclaringType;
			return callingClass == typeof(EchoProcess);
		}
	}
						
	public class Program
	{
		public static void Main()
		{
			var a = EchoProcess.GetPrivateFromMainData();
			var b = MainData.GetStorePrivateData<object, object>();
			
			Console.WriteLine("a={0}", a);
			Console.WriteLine("b={0}", b);
		}
	}
