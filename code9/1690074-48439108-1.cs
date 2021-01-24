    public class MyRunnable : Java.Lang.Object, Java.Lang.IRunnable
    {
        Activity mActivity;
    
        public MyRunnable(Activity activity)
        {
            mActivity = activity;
    
        }
    
        public void Run()
        {
            mActivity.RunOnUiThread(() =>
            {
                Utils.ShowAlert();
    
            }
           );
        }
    }
