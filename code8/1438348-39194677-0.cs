    [Application] //Name is typically a good idea as well
    public class MyApplication : Application
    {
        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        { }
        public override void OnCreate()
        {
                base.OnCreate();
                int myInt = 1;
        }
    }
