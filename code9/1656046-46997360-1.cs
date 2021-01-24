        public static void Enqueue<T>(this ConcurrentQueue<T> queue, IEnumerable<T> items)
        {
            foreach (var item in items)
                queue.Enqueue(item);
        }
    
        concurrentNameQueue.Enqueue(nameList);
        concurrentDateQueue.Enqueue(dateList);
        concurrentVersionQueue.Enqueue(versionList);
        concurrentDownloadQueue.Enqueue(downloadList);
