     using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace RxTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Program();
                p.TestPrioritisedBuffer();
                Console.ReadKey();
    
                
            }
    
            void TestPrioritisedBuffer()
            {
                var source1 = Observable.Interval(TimeSpan.FromSeconds(1)).Do((source) => Console.WriteLine("Source1:"+source));
                var source2 = Observable.Interval(TimeSpan.FromSeconds(5)).Scan((x,y)=>(x+100)).Do((source) => Console.WriteLine("Source2:" + source)); ;
    
                BehaviorSubject<bool> closingSelector = new BehaviorSubject<bool>(true);
    
               
    
                var m = Observable.Merge(source1, source2).
                    Buffer(closingSelector).
                    Select(s => new { list =s.ToList(), max=(long)0 }).
                   Scan((x, y) =>
                   {
                       var list = x.list.Union(y.list).OrderBy(k=>k);
                       
                       var max = list.LastOrDefault();
                      
    
                       var res = new
                       {
                           list = list.Take(list.Count()-1).ToList(),
                           max= max
                       };
    
                       return res;
    
    
    
                   }
                   ).
                   Do((sorted) => Console.WriteLine("Sorted max:" + sorted.max + ".  Priority queue length:" + sorted.list.Count)).
                   ObserveOn(Scheduler.Default); //observe on other thread
    
                m.Subscribe((v)=> { Console.WriteLine("Observed: "+v.max); Thread.Sleep(3000); closingSelector.OnNext(true); }) ;
            }
        }
    }
 
