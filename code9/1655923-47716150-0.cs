        public static IEnumerable<TSource> ToDropQueue<TSource>(
            this IObservable<TSource> source,
            int queueSize,
            Action backPressureNotification = null,
            CancellationToken token = default(CancellationToken))
        {
            var queue = new BlockingCollection<TSource>(new ConcurrentQueue<TSource>(), queueSize);
            var isBackPressureNotified = false;
            var subscription = source.Subscribe(
                item =>
                {
                    var isBackPressure = queue.Count == queue.BoundedCapacity;
                    if (isBackPressure)
                    {
                        queue.Take(); // Dequeue an item to make space for the next one
                        // Fire back-pressure notification if defined
                        if (!isBackPressureNotified && backPressureNotification != null)
                        {
                            backPressureNotification();
                            isBackPressureNotified = true;
                        }
                    }
                    else
                    {
                        isBackPressureNotified = false;
                    }
                    queue.Add(item);
                },
                exception => queue.CompleteAdding(),
                () => queue.CompleteAdding());
            token.Register(() => { subscription.Dispose(); });
            using (new CompositeDisposable(subscription, queue))
            {
                foreach (var item in queue.GetConsumingEnumerable())
                {
                    yield return item;
                }
            }
        }
