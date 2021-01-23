                var producer = Observable.Interval(TimeSpan.FromSeconds(0.2));
                var source = producer.Publish().RefCount();
    
                var onClose = Observable.Return(0L).Publish();
                var onTime = Observable.Timer(TimeSpan.FromSeconds(2));
                var onCount = source.Skip(10);
    
                var bufferClose = Observable.Merge(onClose, onTime, onCount);
            var subscription =
                source
                .Buffer(() => bufferClose)
                .Subscribe(list => Console.WriteLine(string.Join(",", list)));
    
                Console.WriteLine("Waiting for close");
                Console.ReadLine();
                onClose.Connect(); //signal
                subscription.Dispose();
    
                Console.WriteLine("Closed");
    
                Console.ReadLine();
