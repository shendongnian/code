     public static class ObservableExtensions
     {
        public static IObservable<T> PulseDuringInactivity<T>(this IObservable<T> source, TimeSpan pulseInterval, IScheduler scheduler = null)
        {
            return source
                //for each incoming event, we create a new observable stream, that contains this event being repeated infinitely many times over at our pulse interval
                //these repeating values will serve as the pulse
                .Select(sourceValue => RepeatingObservable(sourceValue, pulseInterval, scheduler))
                //However obviously that creates way too many events.  What we we'll do is throw away all of these repeating observables, as soon as there's a single event coming in on any of our streams.
                //this is what .Switch() does, and it immediately unsubscribes from the now-irrelevant streams, which can then be gc'd.  For more information about the workings of this technique,
                //check out the tests in ObservableExtensionTests.cs
                .Switch();
        }
        static IObservable<T> RepeatingObservable<T>(T valueToRepeat, TimeSpan repeatInterval, IScheduler scheduler)
        {
            return Observable.Interval(repeatInterval, scheduler ?? Scheduler.Default).Select(_ => valueToRepeat);
        }
    }
