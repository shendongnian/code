    [Activity(Label = "Tim", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Timer timer = new Timer();
            timer.Schedule(new MyTask(timer),0,1000);
        }
    }
    class MyTask : TimerTask
    {
        Timer mTimer;
        public MyTask(Timer timer) {
            this.mTimer = timer;
        }
        int i;
        public override void Run()
        {
            if (i < 60)
            {
                i++;
            }
            else {
                mTimer.Cancel();
            }
            Android.Util.Log.Error("time",i+"");
        }
    }
