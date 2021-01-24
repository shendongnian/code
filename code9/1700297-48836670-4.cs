	static public class CallPermissionHelper
	{
		static public bool IsAllowed<T>() where T : class
		{
			var frames = new StackTrace().GetFrames();
			var immediateCaller = frames[1].GetMethod().DeclaringType;
			var firstOutsideCaller = frames
				.Skip(2)
				.Select
				(
					f => f.GetMethod().DeclaringType
				)
				.Where
				(
					t => t != immediateCaller 
				)
				.FirstOrDefault();
			return (firstOutsideCaller == typeof(T));
		}
	}
