    public class MyTask
    {
        public int TaskID { get; set; }
        public string ReturnMessage { get; set; }
    }
    private async sometype SomeMethodAsync()
    {
        List<MyTask> _ListOfTasks = new List<MyTask>();
        _ListOfTasks.Add(new MyTask { TaskID = 1, ReturnMessage = string.Empty });
        _ListOfTasks.Add(new MyTask { TaskID = 2, ReturnMessage = string.Empty });
        _ListOfTasks.Add(new MyTask { TaskID = 3, ReturnMessage = string.Empty });
        foreach (MyTask _task in _ListOfTasks)
        {
            _task.ReturnMessage = await DoSomeWorkAsync3(_task.TaskID);
            Console.WriteLine("Message: {0}", _task.ReturnMessage);
        }
    private async Task<string> DoSomeWorkAsync3(int TaskID)
    {
        string _StringToReturn = string.Empty;
        _StringToReturn = await Task.Run(() =>
        {
            switch (TaskID)
            {
                case 1:
                    Thread.Sleep(3000);
                    return "Message From Task 1";
                case 2:
                    Thread.Sleep(1000);
                    return "Message From Task 2";
                case 3:
                    Thread.Sleep(3000);
                    return "Message From Task 3";
                default:
                    return string.Empty;
            }
        });
       return _StringToReturn;
    }
