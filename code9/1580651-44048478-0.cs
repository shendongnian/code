    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DemoWinService
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
    
            System.Timers.Timer _timer;
            List<TimeSpan> timeToRun = new List<TimeSpan>();
            public void OnStart(string[] args)
            {
    
                string timeToRunStr = "19:01;19:02;19:00"; //Time interval on which task will run
                var timeStrArray = timeToRunStr.Split(';');
                CultureInfo provider = CultureInfo.InvariantCulture;
    
                foreach (var strTime in timeStrArray)
                {
                    timeToRun.Add(TimeSpan.ParseExact(strTime, "g", provider));
                }
                _timer = new System.Timers.Timer(60 * 100 * 1000);
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                ResetTimer();
            }
    
    
            void ResetTimer()
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                TimeSpan? nextRunTime = null;
                foreach (TimeSpan runTime in timeToRun)
                {
    
                    if (currentTime < runTime)
                    {
                        nextRunTime = runTime;
                        break;
                    }
                }
                if (!nextRunTime.HasValue)
                {
                    nextRunTime = timeToRun[0].Add(new TimeSpan(24, 0, 0));
                }
                _timer.Interval = (nextRunTime.Value - currentTime).TotalMilliseconds;
                _timer.Enabled = true;
    
            }
    
            private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                _timer.Enabled = false;
                Console.WriteLine("Hello at " + DateTime.Now.ToString()); //You can perform your task here
                ResetTimer();
            }
        }
    }
