        public static async Task ForEachParallel<T>(
          this IEnumerable<T> list, 
          Func<T, Task> action, 
          int dop)
        {
            var tasks = new List<Task>(dop);
            foreach (var item in list)
            {
                tasks.Add(action(item));
        
                while (tasks.Count >= dop)
                {
                    var completed = await Task.WhenAny(tasks).ConfigureAwait(false);
                    tasks.Remove(completed);
                }
            }
            
            // Wait for all remaining tasks.
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        
        // usage
        await Enumerable
            .Range(1, 500)
            .ForEachParallel(i => ProcessItem(i), Environment.ProcessorCount);
