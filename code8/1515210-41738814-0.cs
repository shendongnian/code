	public class BoomerangeCallable<T> : Java.Lang.Object, ICallable
	{
		T value;
		public BoomerangeCallable(T value)
		{
			this.value = value;
		}
		public Java.Lang.Object Call()
		{
			return value.ToString();
		}
	}
