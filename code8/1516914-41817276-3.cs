    namespace so_q_zmq
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.Threading.Tasks;
        using Bond;
        using Bond.IO.Safe;
        using Bond.Protocols;
        using ZeroMQ;
    
        [Schema]
        class Record
        {
            [Id(0)]
            public Dictionary<string, double> payload = new Dictionary<string, double>();
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var pTask = Task.Run(() =>
                {
                    try
                    {
                        Publisher();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Publisher failed: {0}", ex);
                    }
                });
    
                var sTask = Task.Run(() =>
                {
                    try
                    {
                        Subscriber();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Subscriber failed: {0}", ex);
                    }
                });
    
                Task.WaitAll(pTask, sTask);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    
            static void Publisher()
            {
                var ctx = new ZContext();
                var publisher = new ZSocket(ctx, ZSocketType.PUB);
                publisher.Bind("tcp://127.0.0.1:12345");
    
                var src = new Record();
                src.payload.Add("a", 1.0);
                src.payload.Add("b", 2.0);
    
                var output = new OutputBuffer();
                var writer = new CompactBinaryWriter<OutputBuffer>(output);
    
                for (;;)
                {
                    Marshal.To(writer, src);
                    // INCORRECT:
                    // var str = Encoding.ASCII.GetString(output.Data.Array);
                    // var updateFrame = new ZFrame(str);
                    var updateFrame = new ZFrame(output.Data.Array, output.Data.Offset, output.Data.Count);
                    publisher.Send(updateFrame);
                    output.Position = 0;
                }
            }
    
            static void Subscriber()
            {
                var ctx = new ZContext();
                var subscriber = new ZSocket(ctx, ZSocketType.SUB);
                subscriber.Connect("tcp://127.0.0.1:12345");
                subscriber.SubscribeAll();
    
                for (;;)
                {
                    var received = subscriber.ReceiveFrame();
                    // INCORRECT
                    // var str = received.ReadString();
                    // var byteArr = Encoding.ASCII.GetBytes(str);
                    var byteArr = received.Read();
                    var arrSeg = new ArraySegment<byte>(byteArr); // There's an InputBuffer ctor that takes a byte[] directly
                    var input = new InputBuffer(arrSeg);
                    var dst = Unmarshal<Record>.From(input);
                    foreach (var kvp in dst.payload)
                    {
                        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                    }
                }
            }
        }
    }
