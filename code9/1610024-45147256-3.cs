    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SubscribeOnVsObserveOn
    {
        class Program
        {
            static readonly Subject<object> EventsSubject = new Subject<object>();
    
            private static readonly IObservable<object> Events = Observable.Create<object>
                ( observer =>
                {
                    Info( "Subscribing"  );
                    return EventsSubject.Subscribe( observer );
                } );
    
            public static void Info(string msg)
            {
                var currentThread = Thread.CurrentThread;
                var currentThreadName = string.IsNullOrWhiteSpace( currentThread.Name ) ? "<no name>" : currentThread.Name;
                Console.WriteLine
                    ( $"Thread Id {currentThread.ManagedThreadId} {currentThreadName} - " + msg );
            }
    
            public static void  Foo()
            {
                Thread.CurrentThread.Name = "Main Thread";
    
                Info( "Starting"  );
    
                void OnNext(object o) => Info( $"Received {o}" );
    
                void Notify(object obj)
                {
                    Info( $"Sending {obj}"  );
                    EventsSubject.OnNext( obj );
                }
    
                void StartAndSend(object o, string threadName)
                {
                    var thread = new Thread(Notify);
                    thread.Name = threadName;
                    thread.Start(o);
                    thread.Join();
                }
    
                Notify(1);
    
                Console.WriteLine("=============================================" );
                Console.WriteLine("Subscribe Only" );
                Console.WriteLine("=============================================" );
                using (Events.Subscribe(OnNext))
                {
                    Thread.Sleep( 200 );
                    StartAndSend(2, "A");
                    StartAndSend(3, "B");
                }
    
                Console.WriteLine("=============================================" );
                Console.WriteLine("Subscribe With SubscribeOn(CurrentThreadScheduler)" );
                Console.WriteLine("=============================================" );
                using (Events.SubscribeOn( CurrentThreadScheduler.Instance ).Subscribe(OnNext))
                {
                    Thread.Sleep( 200 );
                    StartAndSend(2, "A");
                    StartAndSend(3, "B");
                }
    
                Console.WriteLine("=============================================" );
                Console.WriteLine("Subscribe With SubscribeOn(ThreadPool)" );
                Console.WriteLine("=============================================" );
                using (Events.SubscribeOn( ThreadPoolScheduler.Instance ).Subscribe(OnNext))
                {
                    Thread.Sleep( 200 );
                    StartAndSend(2, "A");
                    StartAndSend(3, "B");
                }
    
                Console.WriteLine("=============================================" );
                Console.WriteLine("Subscribe With SubscribeOn(NewThread)" );
                Console.WriteLine("=============================================" );
                using (Events.SubscribeOn( NewThreadScheduler.Default ).Subscribe(OnNext))
                {
                    Thread.Sleep( 200 );
                    StartAndSend(2, "A");
                    StartAndSend(3, "B");
                }
    
                Console.WriteLine("=============================================" );
                Console.WriteLine("Subscribe With SubscribeOn(NewThread) + ObserveOn" );
                Console.WriteLine("=============================================" );
                using (Events.SubscribeOn( NewThreadScheduler.Default ).ObserveOn(TaskPoolScheduler.Default  ).Subscribe(OnNext))
                {
                    Thread.Sleep( 200 );
                    StartAndSend(2, "A");
                    StartAndSend(3, "B");
                }
            }
    
    
    
    
            static void Main(string[] args)
            {
                Foo();
                Console.WriteLine( "Press Any Key" );
                Console.ReadLine();
            }
        }
    }
