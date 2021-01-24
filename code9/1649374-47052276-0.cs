    public class Program
    {
        static void Main(string[] args) {
            using (var context = new ZContext()) {
                Console.WriteLine($"Curve Supported: {ZeroMQ.ZContext.Has("curve")}");
                byte[] serverPublicKey;
                byte[] serverSecretKey;
                Z85.CurveKeypair(out serverPublicKey, out serverSecretKey);
                var publisher = new ZSocket(context, ZSocketType.PUB);
                publisher.CurvePublicKey = serverPublicKey;
                publisher.CurveSecretKey = serverSecretKey;
                publisher.CurveServer = true;
                publisher.Bind("tcp://*:5050");
                var subscriber = new ZSocket(context, ZSocketType.SUB);
                byte[] subPublicKey;
                byte[] subSecretKey;
                Z85.CurveKeypair(out subPublicKey, out subSecretKey);
                subscriber.CurvePublicKey = subPublicKey;
                subscriber.CurveSecretKey = subSecretKey;
                subscriber.CurveServerKey = serverPublicKey;
                ZError connectError;
                subscriber.Connect("tcp://mybox:5050", out connectError);
                if (connectError != null) {
                    Console.WriteLine($"Connection error: {connectError.Name} - {connectError.Number} - {connectError.Text}");
                }
                subscriber.SubscribeAll();
                // Publish some messages
                Task.Run(() => {
                    for (var i = 1; i <= 5; i++) {
                        var msg = $"Pub msg: {Guid.NewGuid().ToString()}";
                        using (var frame = new ZFrame(msg)) {
                            publisher.Send(frame);
                        }
                    }
                });
                Task.Run(() => {
                    // Receive some messages
                    while (true) {
                        using (var frame = subscriber.ReceiveFrame()) {
                            var msg = frame.ReadString();
                            Console.WriteLine($"Received: {msg}");
                        }
                    }
                });
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
                ZError subError;
                subscriber.Disconnect("tcp://mybox:5050", out subError);
                subscriber.Dispose();
                ZError pubError;
                publisher.Disconnect("tcp://*:5050", out pubError);
                publisher.Dispose();
            }
        }
    }
