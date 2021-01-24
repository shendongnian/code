    public class TaskCollection
    {
        public string version { get; set; }
        public List<Task> tasks { get; set; }
        public static void RunTasks()
        {
            string json = new WebClient().DownloadString("https://gist.githubusercontent.com/eppz/f941f2e85e12e7cc81c63ee2ac1354e5/raw/fa15f7b9774083f481504677b96353fe0da777be/tasks.json");
            TaskCollection col = new JavaScriptSerializer().Deserialize<TaskCollection>(json);
            Parallel.ForEach(col.tasks, (x) =>
            {
                ExecuteTask(x);
            }
            );
        }
        private static void ExecuteTask(Task x)
        {
            //Do something
        }
    }
    public class Task
    {
        public string taskName { get; set; }
        public bool isBuildCommand { get; set; }
        public string command { get; set; }
        public string[] args { get; set; }
        public string showOutput { get; set; }
        public string problemMatcher { get; set; }
        public bool isShellCommand { get; set; }
        public bool isTestCommand { get; set; }
    }
