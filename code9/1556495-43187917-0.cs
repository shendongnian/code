    static IElement  GetLatestElement(Guid id) {
        return new Element();
    }
    public class Element : IElement {
        
    }
    public interface IElement {
        
    }
    class MessageService {
        private Dictionary<Guid, Dictionary<Action<IElement>, CancellationTokenSource>> _subs = new Dictionary<Guid, Dictionary<Action<IElement>, CancellationTokenSource>>();
        public void SubscribeToTopic(Guid id, Action<IElement> callback) {
            var ct = new CancellationTokenSource();
            if (!_subs.ContainsKey(id))
                _subs[id] = new Dictionary<Action<IElement>, CancellationTokenSource>();
            _subs[id].Add(callback, ct);
            Task.Run(() =>
            {
                while (!ct.IsCancellationRequested) {
                    callback(new Element());
                    Thread.Sleep(500);
                }
            });
        }
        public void Unsubscribe(Guid id, Action<IElement> callback) {
            _subs[id][callback].Cancel();
            _subs[id].Remove(callback);
        }
    }
    public static IObservable<IElement> GetElement(Guid id)
    {
        var messageService = new MessageService();
        return Observable.Create<IElement>((observer) =>
        {
            observer.OnNext(GetLatestElement(id));
            // subscribe to internal or external update notifications
            Action<IElement> messageCallback = (message) =>
            {
                // new update message recieved,
                observer.OnNext(GetLatestElement(id));
            };
            messageService.SubscribeToTopic(id, messageCallback);
            return Disposable.Create(() => {
                messageService.Unsubscribe(id, messageCallback);
                Console.WriteLine("Observer Disposed");
            });
        });
    }
    public static void Main(string[] args) {
        var ob = GetElement(Guid.NewGuid());
        var sub1 = ob.Subscribe(c =>
        {
            Console.WriteLine("got element");
        });
        var sub2 = ob.Subscribe(c =>
        {
            Console.WriteLine("got element 2");
        });
        // at this point we see both subscribers receive messages
        Console.ReadKey();
        sub1.Dispose();
        // first one is unsubscribed, but second one is still alive
        Console.ReadKey();
    }
