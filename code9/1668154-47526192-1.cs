    public partial class Form1 : Form
    {
        private const int _kmaxTasks = 4;
        private readonly List<string> _keysList =
            new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        private readonly List<string> _liveKeys = new List<string>();
        private readonly List<string> _deadKeys = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // Initialize a new queue, copying all elements from _keysList to the queue
            Queue<string> keysQueue = new Queue<string>(_keysList);
            // List of tasks, to keep track of active tasks
            //
            // NOTE: value tuple syntax requires that you use the NuGet Package Manager
            // to get Microsoft's "ValueTuple" package installed for your project.
            List<Task<(bool, string)>> tasks = new List<Task<(bool, string)>>();
            button1.Enabled = false;
            _liveKeys.Clear();
            _deadKeys.Clear();
            _UpdateStatus(keysQueue.Count, _liveKeys.Count, _deadKeys.Count);
            // Keep working until we're out of keys *and* out of tasks
            while (keysQueue.Count > 0 || tasks.Count > 0)
            {
                // If we've got the max number of tasks running already, wait for one to
                // complete. Even if we don't have the max number of tasks running, if we're
                // out of keys also wait for one to complete.
                if (tasks.Count >= _kmaxTasks || keysQueue.Count == 0)
                {
                    Task<(bool Live, string Key)> completedTask = await Task.WhenAny(tasks);
                    tasks.Remove(completedTask);
                    if (completedTask.Result.Live)
                    {
                        _liveKeys.Add(completedTask.Result.Key);
                    }
                    else
                    {
                        _deadKeys.Add(completedTask.Result.Key);
                    }
                    _UpdateStatus(
                        keysQueue.Count + tasks.Count, _liveKeys.Count, _deadKeys.Count);
                }
                if (keysQueue.Count > 0)
                {
                    tasks.Add(Worker(keysQueue.Dequeue()));
                }
            }
            statusLabel.Text = "Finished!";
            button1.Enabled = true;
        }
        private void _UpdateStatus(int count, int liveCount, int deadCount)
        {
            statusLabel.Text = $"Only {count} keywords left";
            liveLabel.Text = liveCount.ToString();
            deadLabel.Text = deadCount.ToString();
        }
        private async Task<(bool, string)> Worker(string key)
        {
            string uri = "http://www.somesite.com/";
            using (MockWebClient wc = new MockWebClient())
            {
                string result = await wc.DownloadStringAsync(uri + key);
                return (result.Contains("live"), key);
            }
        }
    }
