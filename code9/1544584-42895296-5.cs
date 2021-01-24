     void Main()
    {
    	const double bufferDuration = 8;
    	var now = DateTimeOffset.Now;
    
    	Console.WriteLine(now);
    	
    	// create a historical log for testing
    	var log = new List<ValueTime>
    			{
    				new ValueTime { Ts = now.AddMilliseconds(-5000).ToString(), Balance = 1L },
    				new ValueTime { Ts = now.AddMilliseconds(-4000).ToString(), Balance = 2L },
    				new ValueTime { Ts = now.AddMilliseconds(-3000).ToString(), Balance = 4L }
    			};
    
    	var scheduler = new HistoricalScheduler();
    
    	scheduler.AdvanceTo(DateTime.Parse(log[0].Ts));
    
    	// historical part of the stream
    	var replay = Observable.Generate(
    			log.ToObservable().GetEnumerator(),
    			events => events.MoveNext(),
    			events => events,
    			events => events.Current.Balance,
    			events => DateTime.Parse(events.Current.Ts),
    			scheduler);
    
    	// create the real time part of the stream using a timer
    	var realTime = Observable.Create<long>(observer =>
    		{
    			var timer = Observable.Interval(TimeSpan.FromSeconds(2)).Select(x => 10 + x);
    			var disposable = timer.Subscribe(x => observer.OnNext(x));
    			return disposable;
    		});
    
    	// combine the two streams
    	var combined = replay
    			.Concat(realTime)
    			.Publish()
    			.RefCount();
    
    	combined.Timestamp(scheduler).Dump("Combined stream");
    
    	// use the real time stream to set the time of the historical scheduler's
    	realTime.Subscribe(_ =>
    		{
    			scheduler.AdvanceTo(DateTime.Now);
    		},
    		ex => Console.WriteLine(ex.Message),
    		() => Console.WriteLine("Done"));
    
    	var combinedRollingBuffer = combined
    			.RollingBufferDeltaChange(TimeSpan.FromSeconds(bufferDuration), scheduler)
    			.Publish()
    			.RefCount();
    			
    	// use a rolling buffer of "bufferDuration" length 
    	var combinedBuffer = combinedRollingBuffer
    			//.Select(x => x.Sum());
    			.Select(x => x.Last() - x.First());
    
    	combinedBuffer.Timestamp(scheduler).Dump($"{bufferDuration}'' Rolling buffer aggregation");
    
    	// display the values that are included in each window of the rolling buffer
    	combinedRollingBuffer
    	.Select(x => string.Join(",", x))
    	.Timestamp(scheduler).Dump($"{bufferDuration}'' Rolling buffer lists");
    
    	scheduler.Start();
    }
    
    class ValueTime
    {
    	public long Balance;
    	public string Ts;
    }
    
    static class Extensions
    {
    	public static IObservable<T[]> RollingBufferDeltaChange<T>(
    		this IObservable<T> @this,
    		TimeSpan buffering, IScheduler scheduler)
    	{
    		return Observable.Create<
    		T[]>(o =>
    		{
    			var list = new LinkedList<Timestamped<T>>();
    			return @this.Timestamp(scheduler).Subscribe(tx =>
    			{
    				list.AddLast(tx);
    				Console.WriteLine($"{scheduler.Now} Adding Tx: {tx.Timestamp}  {tx.Value} list.First: {list.First.Value.Timestamp} {list.First.Value.Value} list.Last: {list.Last.Value.Timestamp} {list.Last.Value.Value}");
    
    				DateTime nowTime = scheduler.Now.DateTime; // DateTime.Now;
    
    				System.Reactive.Timestamped<T> el = default(System.Reactive.Timestamped<T>);
    				while (list.Count > 1 && list.First.Value.Timestamp < nowTime.Subtract(buffering))
    				{
    					el = list.First.Value;
    					list.RemoveFirst();
    
    					Console.WriteLine($"{scheduler.Now} Removing el: {el.Timestamp}  {el.Value} {list.Count}");
    				}
    
    				if (el != default(System.Reactive.Timestamped<T>) && (list.Count <= 1 || list.First.Value.Timestamp > nowTime.Subtract(buffering)))
    				{
    					list.AddFirst(el);
    					Console.WriteLine($"{scheduler.Now} Adding el: {el.Timestamp}  {el.Value} {list.Count}");
    					if (list.Count > 0)
    					{
    						Console.WriteLine($"{scheduler.Now} el: {el.Timestamp}  {el.Value} list.First: {list.First.Value.Timestamp} {list.First.Value.Value} list.Last: {list.Last.Value.Timestamp} {list.Last.Value.Value}");
    					}
    				}
    
    				o.OnNext(list.Select(tx2 => tx2.Value).ToArray());
    
    			}, o.OnError, o.OnCompleted);
    		});
    	}
    }
