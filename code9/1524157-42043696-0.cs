    Subject<int> sub = new Subject<int>();      
    var seq = sub.SelectMany(x =>            
            Observable.Start(() =>
            {
                //time dependent failure
                if (DateTime.Now.Second % 2 == 0)
                    throw new Exception();
                
                Console.WriteLine(x);
                return x;
            })
            .Retry(5)
            .Catch(Observable.Return(x))
        );
    //for testing
    Observable.Interval(TimeSpan.FromSeconds(1)).Select(x => (int)x).Subscribe(sub);
    seq.Wait();
