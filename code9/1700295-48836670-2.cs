	static public class CallPermissionHelper
	{
		static public bool IsAllowed<T>() where T : class
		{
			var stackTrace = new StackTrace();
			var immediateCaller = stackTrace.GetFrame(0).GetMethod().DeclaringType;
			foreach (var f in new StackTrace().GetFrames().Skip(1))
			{
    			var callingClass = f.GetMethod().DeclaringType;
				if (callingClass == immediateCaller) continue;
				if (callingClass == typeof(T)) return true;
			}
			return false;
		}
	}
