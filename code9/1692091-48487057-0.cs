    void TestGroupBy()
            {
                var source1 = Observable.Interval(TimeSpan.FromSeconds(1));
                
                var m = source1.
                    GroupBy(x => { return x % 2 == 0; });
    
                m.Subscribe(
                    v => {
                        Console.WriteLine("Subscribing to " + v.Key);
                        v.ObserveOn(Scheduler.Default).
                        Subscribe(seq =>
                        {
                            Console.WriteLine(Thread.CurrentThread.ManagedThreadId+"   "+seq);
                            
                            });
                    }
                    );
            }
