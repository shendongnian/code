    public class QueueItem
    {
    	public string SessionName { get; }
    
    	public Action<string> Action => i => i = SessionName;
    
    	public QueueItem(string sessionName)
    	{
    		SessionName = sessionName;
    	}
    }
    
    Queue<QueueItem> myQ = new Queue<QueueItem>();
    myQ.Enqueue(new QueueItem("First"));
    myQ.Enqueue(new QueueItem("Second"));
    myQ.Enqueue(new QueueItem("Thrid"));
    int index = myQ.ToList().FindIndex(x => x.SessionName == "First");
