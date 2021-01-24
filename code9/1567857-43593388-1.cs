    internal class countDownTimer
        {
            public int enlapsedTime;
            private DispatcherTimer dispatch;
     
            public delegate void MyCallback();
            public delegate void MyCallback2(int value);
            public MyCallback OnStartTime;
            public MyCallback OnStopTime;
            public MyCallback OnEndTime;
            public MyCallback2 OnCountTime;
     
            public countDownTimer()
            {
                Debug.WriteLine("StopWatch init");
                enlapsedTime = 0;
                dispatch = new DispatcherTimer();
                dispatch.Interval = new TimeSpan(0, 0, 1);
                dispatch.Tick += timer_Tick;
            }
     
            private void timer_Tick(object sender, object e)
            {
                enlapsedTime--;
                Debug.WriteLine(enlapsedTime);
     
                if (OnCountTime != null) OnCountTime(enlapsedTime);
     
                if (enlapsedTime < 0)
                {
                    enlapsedTime = 0;
                    dispatch.Stop();
                    if (OnEndTime != null) OnEndTime();
                }
            }
     
            public void Start()
            {
                dispatch.Start();
                if (OnStartTime != null) OnStartTime();
                Debug.WriteLine("iniciar contador");
            }
     
            public void Stop()
            {
                dispatch.Stop();
                if (OnStopTime != null) OnStopTime();
                Debug.WriteLine("parar contador");
            }
     
            public bool IsEnabled
            {
                get
                {
                    return dispatch.IsEnabled;
                }
            }
     
        }
