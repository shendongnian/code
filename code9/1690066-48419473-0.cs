    public interface IRunnableActivity
    {
        void Run();
    }
    public class MainActivity : Activity, IRunnableActivity
    {
        ...
        public void Run()
        {
            ShowAlert();
        }
    }
    public class SomeOtherActivity : Activity, IRunnableActivity
    {
        ...
        public void Run()
        {
            SomeOtherMethod();
        }
    }
    private class MyRunnable : Java.Lang.Object, Java.Lang.IRunnable
    {
        private IRunnableActivity activity;
    
        public MyRunnable(IRunnableActivity runnableActivity)
        {
            activity = runnableActivity;
        }
    
        public void Run()
        {
            runnableActivity.RunOnUiThread(() =>
            {
                runnableActivity.Run();
            });
        }
    }
