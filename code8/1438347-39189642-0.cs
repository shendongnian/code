	[Application(Name = "com.sushihangover.MyAndroidAppClass")]
 	public class MyApplication : Application
	{
		public MyApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle,transfer) { }
		public override void OnCreate()
		{
			base.OnCreate();
			Log.Debug("SO", "App OnCreate");
		}
	}
