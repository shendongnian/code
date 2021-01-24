    using Castle.Core.Logging; //1: Import Logging namespace
    
    public class TaskAppService : ITaskAppService
    {    
        //2: Getting a logger using property injection
        public ILogger Logger { get; set; }
    
        public TaskAppService()
        {
            //3: Do not write logs if no Logger supplied.
            Logger = NullLogger.Instance;
        }
    
        public void CreateTask(CreateTaskInput input)
        {
            //4: Write logs
            Logger.Info("Creating a new task with description: " + input.Description);
    
            //TODO: save task to database...
        }
    }
