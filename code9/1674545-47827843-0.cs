        public class MyServiceConnection : Java.Lang.Object, IServiceConnection,IUpdate
        {
             MainActivity mainAtivity;
    
            public MyServiceConnection(MainActivity activity)
        {
            IsConnected = false;
            Binder = null;
            mainActivity = activity;
        }
    
        public bool IsConnected { get; private set; }
        public MyServiceBinder Binder { get; private set; }
        public MyService myService;
    
        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            Binder = service as MyServiceBinder;
            myService=Binder.Service;
            myService.SetIUpdate(this);
            //myService.SetActivity(mainActivity);
            IsConnected = this.Binder != null;
    
            string message = "onSecondServiceConnected - ";
    
            if (IsConnected)
            {
                message = message + " bound to service " + name.ClassName;
            }
            else
            {
                message = message + " not bound to service " + name.ClassName;
            }
    
            mainActivity.textSpeed.Text = message;
        }
    
        public void OnServiceDisconnected(ComponentName name)
        {
            IsConnected = false;
            Binder = null;
        }
    
        public void Update()
        {
            mainActivity.UpdateUI();
        }
        }
