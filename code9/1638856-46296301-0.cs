    public class TaskManager : DomainService, ITaskManager
    {
        private readonly IRepository<Task, long> _taskRepository;
        public TaskManager(IRepository<Task, long> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public void GetTasks()
        {
            var tasks = _taskRepository.GetAll().ToList();
        }
    }
