    public class MessageObservableProvider
    {
    	private MessageService messageService;
    	private Dictionary<Guid, IObservable<Unit>> _messageNotifications = new Dictionary<Guid, IObservable<Unit>>();
    	private IObservable<Unit> GetMessageNotifications(Guid id)
    	{
    		return Observable.Create<Unit>((observer) =>
    		{
    			Action<Message> messageCallback = _ => observer.OnNext(Unit.Default);
                messageService.SubscribeToTopic(id, messageCallback);
    
    			return Disposable.Create(() =>
    			{
    				messageService.Unsubscribe(messageCallback);
    				Console.WriteLine("Observer Disposed");
    			});
    		});
    	}
    
    	public IObservable<IElement> GetElement(Guid id)
    	{
    		if(!_messageNotifications.ContainsKey(id))
    			_messageNotifications[id] = GetMessageNotifications(id).Publish().RefCount();
    		
    		return _messageNotifications[id]
    			.Select(_ => GetLatestElement(id))
    			.StartWith(GetLatestElement(id));
        }
    
    	private IElement GetLatestElement(Guid id)
    	{
    		throw new NotImplementedException();
    	}
    }
    
    public class IElement { }
    public class Message { }
    public class MessageService
    {
    	public void SubscribeToTopic(Guid id, Action<Message> callback)
    	{
    		throw new NotImplementedException();
    	}
    
    	public void Unsubscribe(Action<Message> callback)
    	{
    		throw new NotImplementedException();
    	}
    }
