    var taskList = InitQueue();
    foreach (var t in taskList.OrderBy(i => i.Order))
    {
        //Here I can skedule an existing task
    	t.TaskToRun.Start();
    	t.TaskToRun.Wait();
    	Console.WriteLine($"Task {t.Order} has finished its job");
    }
    
    
    public class TaskQueue : List<TaskItem>
    {
    }
    
    public class TaskItem
    {
        public int Order { get; set; }
        public Task TaskToRun { get; set; }
    }
    
    private static TaskQueue InitQueue()
    {
        var queue = new TaskQueue();
        queue.Add(new TaskItem
        {
            Order = 1,
            TaskToRun = new Task(() =>
            {
                Task.Delay(500);
                Console.WriteLine("Hello from task 1");
            })
        });
        queue.Add(new TaskItem
        {
            Order = 4,
            TaskToRun = new Task(() => Console.WriteLine("Hello from task 4"))
        });
        queue.Add(new TaskItem
        {
            Order = 3,
            TaskToRun = new Task(() =>
            {
                Task.Delay(5000);
                Console.WriteLine("Hello from task 3");
            })
        });
        queue.Add(new TaskItem
        {
            Order = 2,
            TaskToRun = new Task(() => Console.WriteLine("Hello from task 2"))
        });
    
        return queue;
    }
