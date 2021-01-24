    using StackExchange.Redis;
    using System;
    using System.Linq;
    using System.Net;
    
    namespace RedisHashSets
    {
        class Program
        {
            static void Main(string[] args)
            {
                var redisClient = RedisProvider.Instance;
                for (int i = 0; i < 10; i++)
                {
                    //Thread.Sleep(100);
                    redisClient.redisPubSub.Publish("InvalidateBalances", Guid.NewGuid().ToString());
                }
                Console.ReadLine();
            }
        }
    
    
        public class RedisProvider
        {
            #region Private Fields
    
            private static readonly Lazy<RedisProvider> lazyObj = new Lazy<RedisProvider>(() => new RedisProvider());
            private ConnectionMultiplexer redisClient;
            private IDatabase redisDatabase;
            private IServer currentServer;
            private EndPoint[] endPoints;
    
    
            public static RedisProvider Instance => lazyObj.Value;
            public ISubscriber redisPubSub;
    
            public bool IsRedisEnableByConfig { get; set; }
    
            private RedisProvider()
            {
                if (!lazyObj.IsValueCreated)
                {
                    IsRedisEnableByConfig = true;
                    redisClient = ConnectionMultiplexer.Connect("localhost");
                    endPoints = redisClient.GetEndPoints();
                 
                    currentServer = redisClient.GetServer(endPoints.First());
                    ManageSubscriber();
                } 
            }
    
            private void ManageSubscriber()
            {
                redisPubSub = redisClient.GetSubscriber();
                redisPubSub.Subscribe(new RedisChannel("InvalidateBalances", RedisChannel.PatternMode.Pattern), (channel, message) => MessageAction(message));
            }
    
            private void MessageAction(RedisValue message)
            {
                Console.WriteLine("msg arrived: " + message);
            }
    
            #endregion
        }
    }
