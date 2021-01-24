    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncTest
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                var data = new List<object>() 
                {
                    1, 2, "three", 4, 5
                };
    
                // Transform the data into a sequence of Tasks. Note that this does not start these tasks running.
                IEnumerable<Task> tasks = data.Select(async (o) =>
                {
                    Console.WriteLine($"Processing: {o}");
                    await Task.Delay(1000);
                    if (o is string s) throw new InvalidOperationException($"Cannot perform operation on string '{s}'");
                });
    
                try 
                {
                    Console.WriteLine("Starting asynchronous processing"); 
                    // This call starts all the Tasks in the sequence running. If any of those tasks raises an exception
                    // the use of the await operator will rethrow that exception here, so we can catch it
                    await Task.WhenAll(tasks);
                    Console.WriteLine("All tasks processed successfully");
                } 
                catch (InvalidOperationException e) 
                {
                    Console.WriteLine($"Error performing asynchronous work: {e.Message}");
                    Console.WriteLine("Not all tasks processed successfully");
                }
    
                Console.WriteLine("Asynchronous processing finished. Exiting.");
            }        
        }
    }
