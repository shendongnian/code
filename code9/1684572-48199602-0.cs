    public class AppCommand : IExternalApplication
    {
        private static Queue<Action<UIApplication>> Tasks;
        public Result OnStartup(UIControlledApplication application)
        {
            Tasks = new Queue<Action<UIApplication>>();
            application.Idling += OnIdling;
    
            return Result.Succeeded;
        }
        private static void OnIdling(object sender, IdlingEventArgs e)
        {
            var app = (UIApplication)sender;
            lock (Tasks)
            {
                if (Tasks.Count <= 0) return;
    
                var task = Tasks.Dequeue();
                task(app);
            }
        }
        public static void EnqueueTask(Action<UIApplication> task)
        {
            lock (Tasks)
            {
                Tasks.Enqueue(task);
            }
        }
    }
