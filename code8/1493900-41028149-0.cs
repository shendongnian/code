    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    class Record
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
    }
    class RecordComparer : IComparer<Record>
    {
        public int Compare(Record x, Record y)
        {
            // Sort by Name, Age, and then Salary
            if (x.Name != y.Name) return x.Name.CompareTo(y.Name);
            if (x.Age != y.Age) return x.Age.CompareTo(y.Age);
            return x.Salary.CompareTo(y.Salary);
        }
    }
    class Program
    {
        static Random _random = new Random();
        static List<Record> _list;
        static void Main(string[] args)
        {
            Profile("SortUsingLinqMethodChain", 50, InitList, SortUsingLinqMethodChain);
            Profile("SortUsingLinqComparer", 50, InitList, SortUsingLinqComparer);
            Profile("SortUsingListSort", 50, InitList, SortUsingListSort);
        }
        static void InitList()
        {
            _list = new List<Record>();
            for (int i = 0; i < 10000; i++)
            {
                _list.Add(new Record { Name = RandomString(12), Age = RandomAge() });
            }
        }
        static void SortUsingLinqMethodChain()
        {
            // NOTE: the `ToList` materialization may not be necessary at all
            //    This totally depends on what you want to do with the result.
            _list = _list.OrderBy(item => item.Name)
                         .ThenBy(item => item.Age)
                         .ThenBy(item => item.Salary).ToList();
        }
        static void SortUsingLinqComparer()
        {
            // NOTE: the `ToList` materialization may not be necessary at all
            //    This totally depends on what you want to do with the result.
            _list = _list.OrderBy(item => item, new RecordComparer()).ToList();
        }
        static void SortUsingListSort()
        {
            _list.Sort(new RecordComparer());
        }
        // based on http://stackoverflow.com/a/1344242/40347
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
        public static int RandomAge()
        {
            return _random.Next(100) + 1;
        }
        public static double RandomSalary()
        {
            return _random.NextDouble() * 100000;
        }
        // based on http://stackoverflow.com/a/1048708/40347
        static double Profile(string description, int iterations, Action init, Action func)
        {
            // Run at highest priority to minimize fluctuations 
            // caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            // warm up 
            init();
            func();
            var watch = new Stopwatch();
            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            for (int i = 0; i < iterations; i++)
            {
                init();
                watch.Start();
                func();
                watch.Stop();
            }
            
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds);
            return watch.Elapsed.TotalMilliseconds;
        }
    }
