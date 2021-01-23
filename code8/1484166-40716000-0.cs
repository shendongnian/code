    namespace TaskAsyncTests
    {
        using System.Threading.Tasks;
        class Program
        {
            static async Task<KeyValuePair<string, long>> TaskThis(Func<string> fn)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                var task = Task.Run(fn); //fn will be 1sec
                await Task.Delay(1000);  //also being delayed 1sec here
                var result = await task;
                watch.Stop();
                return new KeyValuePair<string, long>(result, watch.ElapsedMilliseconds); //result should only be approx. 1 sec though
            }
            static void Main(string[] args)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                var results = Run(Task.WhenAll(new[]
                {
                    TaskThis(LongProcessingFunction),
                    TaskThis(LongProcessingFunction),
                    TaskThis(LongProcessingFunction),
                }));
                watch.Stop();
                foreach (KeyValuePair<string, long> item in results)
                {
                    Console.WriteLine(@"result:= '{0}' ElapsedMilliseconds := {1}", item.Key, item.Value.ToString());
                }
                Console.WriteLine("total ElapsedMilliseconds := {0}", watch.ElapsedMilliseconds);
                watch.Reset();
                watch.Start();
                var result = Run(GetSomethingAsync());
                watch.Stop();
                Console.WriteLine(@"result->PropertyOne := '{0}' ElapsedMilliseconds := {1}", result.PropertyOne.Key, result.PropertyOne.Value.ToString());
                Console.WriteLine(@"result->PropertyTwo := '{0}' ElapsedMilliseconds := {1}", result.PropertyTwo.Key, result.PropertyTwo.Value.ToString());
                Console.WriteLine(@"result->PropertyThree := '{0}' ElapsedMilliseconds := {1}", result.PropertyThree.Key, result.PropertyThree.Value.ToString());
                Console.WriteLine("total ElapsedMilliseconds := {0}", watch.ElapsedMilliseconds);
                Console.ReadLine();
            }
            static string LongProcessingFunction()
            {
                Task.Delay(1000).Wait();
                return "Hello World";
            }
            static T Run<T>(Task<T> taskRunner)
            {
                return taskRunner.Result;
            }
            static T[] Run<T>(Task<T[]> taskRunner)
            {
                return taskRunner.Result;
            }
            static async Task<dynamic> GetSomethingAsync()
            {
                var resultsTask = Task.WhenAll(new[] 
                {
                    TaskThis(LongProcessingFunction),
                    TaskThis(LongProcessingFunction),
                    TaskThis(LongProcessingFunction)
                }).ConfigureAwait(false);
                // do other stuff here
                Task.Delay(2000).Wait();
                var results = await resultsTask;
                return new
                {
                    PropertyOne = results[0],
                    PropertyTwo = results[1],
                    PropertyThree = results[2]
                };
            }
        }
    }
