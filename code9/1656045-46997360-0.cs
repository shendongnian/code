        public static void Enqueue<T>(this ConcurrentQueue<T> queue, IEnumerable<T> items)
        {
            foreach (var item in items)
                queue.Enqueue(item);
        }
    
        concurrentNameQueue(nameList);
        concurrentDateQueue(dateList);
        concurrentVersionQueue(versionList);
        concurrentDownloadQueue(downloadList);
