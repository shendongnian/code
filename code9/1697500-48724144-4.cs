    var messages = new ConcurrentQueue<string>();
    //or
    //var lockObj = new object();
    public int main()
    {
        var fileText = File.ReadAllLines(@"file.txt");
        
        var taskList = new List<Task>();
        foreach (var line in fileText)
        {
            taskList.Add(Task.Factory.StartNew(HandlerMethod, line));
            //you can control the amount of produced task if you want:
            //if(taskList.Count > 20)
            //{
            //    Task.WaitAll(taskList.ToArray());
            //    taskList.Clear();
            //}
        }
        Task.WaitAll(taskList.ToArray()); //this line may not work as I expected.
        //for the first way
        var results = new StringBuilder();
        foreach (var msg in messages)
        {
            results.AppendLine("{0} : {1}", line, level);
        }
        File.WriteAllText("path", results.ToString());
    }
