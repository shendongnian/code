	static public class CallPermissionHelper
	{
		static public bool IsAllowed<T>() where T : class
		{
			var callers = new StackTrace()
				.GetFrames()
				.Select
				(
					f => f.GetMethod().DeclaringType
				);
			var immediateCaller = callers.ElementAt(1);
			var firstOutsideCaller = callers
				.Skip(2)
				.Where
				(
					t => t != immediateCaller 
				)
				.FirstOrDefault();
			return (firstOutsideCaller == typeof(T));
		}
	}
