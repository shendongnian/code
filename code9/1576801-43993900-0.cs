    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace _43909210
    {
        public static class EnumerableExtensions
        {
            private static async Task<Dictionary<TKey, TValue>> ToDictionary<TKey,TValue>
                (this IEnumerable<(TKey key, Func<Task<TValue>> valueTask)> source)
            {
    
                var results = await Task.WhenAll
                    ( source.Select( async e => (  key: e.key, value:await e.valueTask() ) ) );
    
                return results.ToDictionary(v=>v.key, v=>v.value);
            }
    
            public class ActionDisposable : IDisposable
            {
                private readonly Action _Action;
                public ActionDisposable(Action action) => _Action = action;
                public void Dispose() => _Action();
            }
    
            public static async Task<IDisposable> Enter(this SemaphoreSlim s)
            {
                await s.WaitAsync();
                return new ActionDisposable( () => s.Release() );
            }
    
    
            /// <summary>
            /// Generate a dictionary asynchronously with up to 'n' tasks running in parallel.
            /// If n = 0 then there is no limit set and all tasks are started together.
            /// </summary>
            /// <returns></returns>
            public static async Task<Dictionary<TKey, TValue>> ToDictionaryParallel<TKey,TValue>
                ( this IEnumerable<(TKey key, Func<Task<TValue>> valueTaskFactory)> source
                , int n = 0
                )
            {
                // Delegate to the non limiting case where 
                if (n <= 0)
                    return await ToDictionary( source );
    
                // Set up the parallel limiting semaphore
                using (var pLimit = new SemaphoreSlim( n ))
                {
                    var dict = new Dictionary<TKey, TValue>();
    
                    // Local function to start the task and
                    // block (asynchronously ) when too many
                    // tasks are running
                    async Task
                        Run((TKey key, Func<Task<TValue>> valueTask) o)
                    {
                        // async block if the parallel limit is reached
                        using (await pLimit.Enter())
                        {
                            dict.Add(o.key, await o.valueTask());
                        }
                    }
    
                    // Proceed to start the tasks
                    foreach (var task in source.Select( Run ))
                        await task;
    
                    // Wait for all tasks to finish
                    await pLimit.WaitAsync();
                    return dict;
                }
    
            }
        }
    
    }
