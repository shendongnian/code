    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Android.Views;
    using System.Collections.Generic;
    using Android.Content;
    
    namespace App1
    {
        [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
            private LinearLayout _contentLayout;
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                SetContentView(Resource.Layout.Main);
    
                _contentLayout = FindViewById<LinearLayout>(Resource.Id.contentLayout);
    
                List<MyJob> jobs = GetJobs();
                _contentLayout.AddView(GetButtons(this, jobs));
            }
    
            private List<MyJob> GetJobs()
            {
                return new List<MyJob>()
                       {
                           new MyJob() { Text = "First Job", Priority = MyJob.PriorityEnum.Low },
                           new MyJob() { Text = "Second Job", Priority = MyJob.PriorityEnum.Medium },
                           new MyJob() { Text = "Third Job", Priority = MyJob.PriorityEnum.High },
                           new MyJob() { Text = "Fourth Job", Priority = MyJob.PriorityEnum.Low },
                       };
            }
    
            private ViewGroup GetButtons(Context context, List<MyJob> jobs)
            {
                if (jobs == null || jobs.Count == 0)
                {
                    return null;
                }
    
                LinearLayout buttonLayout = new LinearLayout(context)
                                            {
                                                Orientation = Orientation.Vertical,
                                                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
                                            };
    
                foreach (MyJob job in jobs)
                {
                    Button button = new Button(context)
                                    {
                                        LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent),
                                        Text = job.Text,
                                    };
    
                    button.SetBackgroundColor(GetButtonColor(job.Priority));
    
                    buttonLayout.AddView(button);
                }
    
                return buttonLayout;
            }
    
            private Android.Graphics.Color GetButtonColor(MyJob.PriorityEnum priority)
            {
                switch (priority)
                {
                    case MyJob.PriorityEnum.High:
                        return new Android.Graphics.Color(255, 0, 0);
                    case MyJob.PriorityEnum.Medium:
                        return new Android.Graphics.Color(255, 255, 0);
                    case MyJob.PriorityEnum.Low:
                    default:
                        return new Android.Graphics.Color(0, 255, 0);
                }
            }
        }
    
        internal class MyJob
        {
            public enum PriorityEnum { Low, Medium, High }
            public string Text { get; set; }
            public PriorityEnum Priority { get; set; }
        }
    }
