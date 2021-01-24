        list.AddLast(tx);
        
        var nowTime = scheduler.Now.DateTime;
        System.Reactive.Timestamped<T> el = default(System.Reactive.Timestamped<T>);
        while (list.Count > 1 && list.First.Value.Timestamp < nowTime.Subtract(buffering))
        {
        	el = list.First.Value;
        	list.RemoveFirst();
        }
        
        if (el != default(System.Reactive.Timestamped<T>) && (list.Count <= 1 || list.First.Value.Timestamp > nowTime.Subtract(buffering)))
        {
            list.AddFirst(el);
        }
        o.OnNext(list.Select(tx2 => tx2.Value).ToArray());
