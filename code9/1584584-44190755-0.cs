        static class QueueExtensions
        {
            public static void Test()
            {
                // See that due to the extension method below, now queue can also take advantage of the collection initializer syntax.
                var queue = new Queue<int> { 1, 2, 3, 5 };
            }
    
            public static void Add<T>(this Queue<T> queue, T element)
            {
                queue.Enqueue(element);
            }
        }
