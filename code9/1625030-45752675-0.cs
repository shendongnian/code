    public class WorkerFactory :IFactory<IWorker>
    {
    public IEnumerable<IWorker> Create(int n)
    {
    var workers = new List<IWorker>();
    for(int i = 0; i<n;i++)
    workers.Add(new Worker());
    return workers;
    }
    }
     public ServiceManagement(IFactory<IWorker> workersFactory)
    {
    Workers = workersFactory.Create(5);
    }
