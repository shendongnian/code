    public class FileProcessor
    {
        public async Task ProcessFile()
        {
            List<Task> tasks = new List<Task>();
            var lines = File.ReadAllLines("File.txt").Batch(100);
            foreach (IEnumerable<string> linesBatch in lines)
            {
                IEnumerable<string> localLinesBatch = linesBatch;
                Task task = Task.Factory.StartNew(() =>
                {
                    // Perform operation on localLinesBatch
                });
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }
    }
    public static class LinqExtensions
    {
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
                  this IEnumerable<TSource> source, int size)
        {
            TSource[] bucket = null;
            var count = 0;
            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new TSource[size];
                bucket[count++] = item;
                if (count != size)
                    continue;
                yield return bucket;
                bucket = null;
                count = 0;
            }
            if (bucket != null && count > 0)
                yield return bucket.Take(count);
        }
    }
