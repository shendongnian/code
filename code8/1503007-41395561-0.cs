    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    namespace ConsoleApplicationScheduler
    {
        class Program
        {
            static void Main(string[] args)
            {
                ConcurrentSaveService service = new ConcurrentSaveService();
                int entity = 1;
                for (int i = 0; i < 10; i++)
                {
                    //Save the same record 10 times(this could be conrurrent)
                    service.BeginSave(entity);
                }
                Console.ReadLine();
            }
        }
        public class ConcurrentSaveService
        {
            private static readonly ConcurrentDictionary<int, DateTime> _trackedSubjectsDictionary = new ConcurrentDictionary<int, DateTime>();
            private readonly int _delayInSeconds;
            public ConcurrentSaveService()
            {
                _delayInSeconds = 5;
            }
            public async void BeginSave(int key)
            {
                Console.WriteLine("Started Saving");
                DateTime existingTaskDate;
                _trackedSubjectsDictionary.TryGetValue(key, out existingTaskDate);
                DateTime scheduledDate = DateTime.Now.AddSeconds(_delayInSeconds);
                _trackedSubjectsDictionary.AddOrUpdate(key, scheduledDate, (i, d) => scheduledDate);
                if (existingTaskDate > DateTime.Now)
                    return;
                do
                {
                    await Task.Delay(TimeSpan.FromSeconds(_delayInSeconds));
                    DateTime loadedScheduledDate;
                    _trackedSubjectsDictionary.TryGetValue(key, out loadedScheduledDate);
                    if (loadedScheduledDate > DateTime.Now)
                        continue;
                    if (loadedScheduledDate == DateTime.MinValue)
                        break;
                    _trackedSubjectsDictionary.TryRemove(key, out loadedScheduledDate);
                    if (loadedScheduledDate > DateTime.MinValue)
                    {
                        //DoWork
                        Console.WriteLine("Update/Insert record:" + key);
                    }
                    break;
                } while (true);
                Console.WriteLine("Finished Saving");
            }
        }
    }
