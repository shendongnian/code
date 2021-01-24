    public class QueueItem
    {
    	public string SessionName { get; }
    
    	public Func<string> Func => () => SessionName;
    
    	public QueueItem(string sessionName)
    	{
    		SessionName = sessionName;
    	}
    }
    
    Queue<QueueItem> myQ = new Queue<QueueItem>();
    myQ.Enqueue(new QueueItem("First"));
    myQ.Enqueue(new QueueItem("Second"));
    myQ.Enqueue(new QueueItem("Thrid"));
    var queueList = myQ.ToList();
    int index = queueList.FindIndex(x => x.SessionName == "First");
    var result = queueList[index].Func();
