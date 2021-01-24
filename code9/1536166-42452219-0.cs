    internal class Program
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        private static void Main(string[] args)
        {
            Action<object> action = (object obj) =>
            {
                int i = 0;
                do
                {
                    Thread.Sleep(500);
                    i++;
                } while (i < 10);
                Console.WriteLine("t1 has been finished");
            };
            Action<object> action1 = (object obj) =>
            {
                DialogResult result = DialogResult.OK;
                do
                {
                    result = MessageBox.Show("This is task2", "Task2", MessageBoxButtons.OKCancel);
                } while (result != DialogResult.Cancel);
                Console.WriteLine("t2 has been finished");
            };
            var tasks = new Task[2];
            var source1 = new CancellationTokenSource();
            var token1 = source1.Token;
            Task t1 = new Task(action, "alpha", token1);
            tasks[0] = t1;
            Task t2 = new Task(action1, "betha");
            tasks[1] = t2;
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                Thread.CurrentThread.ManagedThreadId);
            t2.Start();
            Console.WriteLine("t2 has been launched. (Main Thread={0})",
                Thread.CurrentThread.ManagedThreadId);
            try
            {
                int index = Task.WaitAny(tasks);
                if (t1.Status == TaskStatus.Running)
                    source1.Cancel();
                if (t2.Status == TaskStatus.Running)
                    CloseMessage();
                Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
                Console.WriteLine("Status of all tasks:");
                foreach (var t in tasks)
                    Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
            }
            catch (AggregateException)
            {
                Console.WriteLine("An exception occurred.");
            }
            Console.ReadLine();
        }
        private static void CloseMessage()
        {
            int window = FindWindow(null, "Task2");
            if (window != 0)
                SendMessage(window, WM_SYSCOMMAND, SC_CLOSE, 0);
        }
    }
