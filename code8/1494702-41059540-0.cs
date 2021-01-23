    public static void MyTask(string taskId)
        {
            if (!taskId.Equals(Environment.MachineName))
            {
                return;
            }
            Debug.WriteLine(taskId);
        }
