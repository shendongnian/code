        public static IObservable<T> Playback<T>(
            this IEnumerable<Timestamped<T>> enumerable,
            IObservable<DateTimeOffset> ticks,
            HistoricalScheduler scheduler = default(HistoricalScheduler)
        )
        {
            return Observable.Create<T>(observer =>
            {
                scheduler = scheduler ?? new HistoricalScheduler();
                //create enumerator of sequence - we're going to iterate through it manually
                var enumerator = enumerable.GetEnumerator();
                //set scheduler time for every incoming value of ticks
                var timeD = ticks.Subscribe(scheduler.AdvanceTo);
                //declare an iterator 
                Action scheduleNext = default(Action);
                scheduleNext = () =>
                {
                    //move
                    if (!enumerator.MoveNext())
                    {
                        //no more items
                        //sequence has completed
                        observer.OnCompleted();
                        return;
                    }
                    //current item of enumerable sequence
                    var current = enumerator.Current;
                    //schedule the item to run at the timestamp specified
                    scheduler.ScheduleAbsolute(current.Timestamp, () =>
                    {
                        //push the value forward
                        observer.OnNext(current.Value);
                        //schedule the next item
                        scheduleNext();                        
                    });
                };
                //start the process by scheduling the first item
                scheduleNext();
                //dispose the enumerator and subscription to ticks
                return new CompositeDisposable(timeD, enumerator);
            });
        }
