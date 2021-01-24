    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using log4net;
    
        namespace MyApp
        {
            public interface IMessageQueue
            {
                void Subscribe(string topic, IMessageSubscriber subscriber);
                void UnSubscribe(string topic, IMessageSubscriber subscriber);
                void Notify(string topic, Dictionary<string, string> fields);
                bool AnyoneInterested(string topic);
            }
        
            public class MessageQueue : IMessageQueue
            {
                private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
                private readonly Dictionary<string, List<IMessageSubscriber>> subscriptions =
                    new Dictionary<string, List<IMessageSubscriber>>();
        
                private static MessageQueue instance;
        
                private MessageQueue()
                {
                }
        
                public static MessageQueue GetInstance()
                {
                    return instance ?? (instance = new MessageQueue());
                }
        
                public void Subscribe(string topic, IMessageSubscriber subscriber)
                {
                    lock (subscriptions)
                    {
                        if (subscriptions.ContainsKey(topic))
                        {
                            subscriptions[topic].Add(subscriber);
                        }
                        else
                        {
                            subscriptions.Add(topic, new List<IMessageSubscriber> {subscriber});
                        }
                    }
                }
        
                public void UnSubscribe(string topic, IMessageSubscriber subscriber)
                {
                    lock (subscriptions)
                    {
                        if (subscriptions != null && !subscriptions.ContainsKey(topic)) return;
        
                        subscriptions[topic].Remove(subscriber);
                    }
                }
        
                public void Notify(string topic, Dictionary<string, string> fields)
                {
                    lock (subscriptions)
                    {
                        if (!subscriptions.ContainsKey(topic)) return;
        
                        log.Info($"Message: {topic}");
        
                        foreach (var sub in subscriptions[topic])
                        {
                            Task.Run(() =>
                            {
                                try
                                {
                                    sub.Notify(topic, fields);
                                }
                                catch
                                {
                                    //supress, should only get here if someone disposed a subscriber without calling unsubscribe
                                }
                            });
                        }
                    }
                }
        
                public bool AnyoneInterested(string topic)
                {
                    lock (subscriptions)
                    {
                        return subscriptions.ContainsKey(topic);
                    }
                }
            }
        }
