    using System;
    using System.IO;
    using System.Windows.Forms;
    using Quartz;
    using Quartz.Impl;
    using System.Timers;
    
    namespace SchedulerWithTimer
    {
        public partial class frmMain : Form, IJob
        {
            private int imageNumber = 1, SlideCount = 0;
            string _SlideSource = "";
            System.Timers.Timer aTimer = new System.Timers.Timer();
    
            IScheduler sched = null;
    
            public frmMain()
            {
                InitializeComponent();
                _SlideSource = Utility.SlidePath;
                SlideCount = Directory.GetFiles(_SlideSource, "*", SearchOption.AllDirectories).Length;
    
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 5000;
    
                aTimer.Enabled = false;
            }
    
            private void frmMain_Load(object sender, EventArgs e)
            {
                // construct a scheduler factory
                ISchedulerFactory schedFact = new StdSchedulerFactory();
    
                // get a scheduler
                sched = schedFact.GetScheduler();
                sched.Start();
    
                IJobDetail job = JobBuilder.Create<frmMain>()
                    .WithIdentity("Job", "group")
                    .Build();
    
                job.JobDataMap.Put("Form", this);
    
                ITrigger trigger = TriggerBuilder.Create()
                   .WithDailyTimeIntervalSchedule
                     (s =>
                        s.WithIntervalInHours(24)
                       .OnEveryDay()
                       .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(20, 27))
                     )
                   .Build();
    
                sched.ScheduleJob(job, trigger);
            }
    
            public void Execute(IJobExecutionContext context)
            {
                var dataMap = context.MergedJobDataMap;
                var frmInstance = (frmMain) dataMap["Form"];
                frmInstance.generate();
            }
    
    
            public void generate()
            {
                FetchStart();
                System.Threading.Thread.Sleep(5000);
                FetchDone();
            }
    
            public void FetchStart()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate()
                    {
                        aTimer.Enabled = false;
                        picSlide.SizeMode = PictureBoxSizeMode.CenterImage;
                        picSlide.Image = SchedulerWithTimer.Properties.Resources.loading;
                    }));
                }
                else
                {
                    aTimer.Enabled = false;
                    picSlide.SizeMode = PictureBoxSizeMode.CenterImage;
                    picSlide.Image = SchedulerWithTimer.Properties.Resources.loading;
                }
    
            }
    
            public void FetchDone()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate()
                    {
                        aTimer.Enabled = true;
                    }));
                }
                else
                    aTimer.Enabled = true;
            }
    
            
            private void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate()
                    {
                        loadNextImage();
                    }));
                }
                else
                    loadNextImage();
            }
    
            private void loadNextImage()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(delegate()
                    {
                        if (imageNumber == SlideCount)
                        {
                            imageNumber = 1;
                        }
                        picSlide.SizeMode = PictureBoxSizeMode.Zoom;
                        picSlide.ImageLocation = string.Format(_SlideSource + @"\Slide{0}.jpg", imageNumber);
    
                    }));
                }
                else
                {
                    if (imageNumber == SlideCount)
                    {
                        imageNumber = 1;
                    }
                    picSlide.SizeMode = PictureBoxSizeMode.Zoom;
                    picSlide.ImageLocation = string.Format(_SlideSource + @"\Slide{0}.jpg", imageNumber);
                    imageNumber++;
                }
            }
        }
    }
