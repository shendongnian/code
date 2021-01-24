    using System;
    using EasyNetQ;
    using Messages;
    namespace Producer
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var bus = RabbitHutch.CreateBus("host=zzz;username=zzz;password=zzz"))
                {
                    var random = new Random();
                    for (var i = 0; i < 100; ++i)
                    {
                        var coin = random.Next(0, 2);
                        if (coin == 0)
                        {
                            bus.Publish(new CoinFlipMessage { Payload = "Heads" }, CoinFlipMessage.HeadsTopic);
                            Console.WriteLine($"Published message {i} to {CoinFlipMessage.HeadsTopic}");
                        }
                        else
                        {
                            bus.Publish(new CoinFlipMessage { Payload = "Tails" }, CoinFlipMessage.TailsTopic);
                            Console.WriteLine($"Published message {i} to {CoinFlipMessage.TailsTopic}.");
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
    }
