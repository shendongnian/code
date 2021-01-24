	internal sealed class EchoProcess : MainData
	{
		private class Key {}
		public static string GetPrivateFromMainData()
		{
			return MainData.GetStorePrivateData<EchoProcess, Key>();
		}
	}
	
	internal class MainData
	{
		public static string GetStorePrivateData<TEcho, TKey>() where TEcho : class where TKey : class
		{
			var allowed = CallPermissionHelper.IsAllowed<EchoProcess>();  //Magic!!!
			return allowed ? "Allowed" : "Blocked";
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
