    private void StartServiceButton_Click(object sender, System.EventArgs e)
    {
        MyService myService = new MyService();
        if (!isServiceRun("MyService"))
        {
            Toast.MakeText(this, "Service not running", ToastLength.Long).Show();
            Application.Context.StartService(intent);
        }
        else
        {
            Toast.MakeText(this, "Service already running", ToastLength.Long).Show();
            StopService(new Intent(this,typeof(MyService)));
        }
    }
    public  bool isServiceRun( string className)
    {
        bool isRun = false;
        ActivityManager activityManager = (ActivityManager)this.GetSystemService(Context.ActivityService);
        IList<ActivityManager.RunningServiceInfo> serviceList = activityManager.GetRunningServices(40);
        int size = serviceList.Count;
        for (int i = 0; i < size; i++)
        {
            Android.Util.Log.Error("Service Name=====", serviceList[i].Service.ClassName);
            if (serviceList[i].Service.ClassName.Contains(className) == true)
            {
                isRun = true;
                break;
            }
        }
        return isRun;
    }
