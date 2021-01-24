    using System;
    using System.IO;
    using EasyNetQ;
    using Messages;
    namespace Consumer
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var bus = RabbitHutch.CreateBus("host=zzz;username=zzz;password=zzz"))
                {
                    
                    bus.Subscribe<CoinFlipMessage>(CoinFlipMessage.HeadsTopic, HandleHeads, config => config.WithTopic(CoinFlipMessage.HeadsTopic));
                    bus.Subscribe<CoinFlipMessage>(CoinFlipMessage.TailsTopic, HandleTails, config => config.WithTopic(CoinFlipMessage.TailsTopic));
                    Console.ReadLine();
                }
            }
            private static void HandleHeads(CoinFlipMessage message)
            {
                if (message == null) return;
                headsCount++;
                var payload = message.Payload;
                Console.WriteLine($"Received {payload} {headsCount} from {CoinFlipMessage.HeadsTopic}.");
                File.AppendAllText(@"heads.txt", payload + Environment.NewLine);
            }
            private static void HandleTails(CoinFlipMessage message)
            {
                if (message == null) return;
                tailsCount++;
                var payload = message.Payload;
                Console.WriteLine($"Received {payload} {tailsCount} from {CoinFlipMessage.TailsTopic}.");
                File.AppendAllText(@"tails.txt", payload + Environment.NewLine);
            }
            private static int headsCount;
            private static int tailsCount;
        }
    }
