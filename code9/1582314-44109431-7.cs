    using System;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Nito.AsyncEx;
    using System.Threading;
    
    #pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    
    public static class EnumerableExtensions
    {
        public static IEnumerable<Func<U>> Defer<T, U>
            ( this IEnumerable<T> source, Func<T, U> selector) 
            => source.Select(s => (Func<U>)(() => selector(s)));
    }
    
    
    public class Program
    {
        /// <summary>
        /// Returns the time to wait before processing another item
        /// if the rate limit is to be maintained
        /// </summary>
        /// <param name="desiredRateLimit"></param>
        /// <param name="currentItemCount"></param>
        /// <param name="elapsedTotalSeconds"></param>
        /// <returns></returns>
        private static double Delay(double desiredRateLimit, int currentItemCount, double elapsedTotalSeconds)
        {
            var time = elapsedTotalSeconds;
            var timeout = currentItemCount / desiredRateLimit;
            return timeout - time;
        }
    
        /// <summary>
        /// Consume the tasks in parallel but with a rate limit. The results
        /// are returned as an observable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tasks"></param>
        /// <param name="rateLimit"></param>
        /// <returns></returns>
    	public static IObservable<T> RateLimit<T>(IEnumerable<Func<Task<T>>> tasks, double rateLimit){
    	    var s = System.Diagnostics.Stopwatch.StartNew();
    		var n = 0;
    		var sem = new  AsyncCountdownEvent(1);
    
            var errors = new ConcurrentBag<Exception>();
    
    	    return Observable.Create<T>
    	        ( observer =>
    	        {
    
    	            var ctx = new CancellationTokenSource();
    	            Task.Run
    	                ( async () =>
    	                {
    	                    foreach (var taskFn in tasks)
    	                    {
    	                        n++;
                                ctx.Token.ThrowIfCancellationRequested();
    
    	                        var elapsedTotalSeconds = s.Elapsed.TotalSeconds;
    	                        var delay = Delay( rateLimit, n, elapsedTotalSeconds );
    	                        if (delay > 0)
    	                            await Task.Delay( TimeSpan.FromSeconds( delay ), ctx.Token );
    
    	                        sem.AddCount( 1 );
    	                        Task.Run
    	                            ( async () =>
    	                            {
    	                                try
    	                                {
    	                                    observer.OnNext( await taskFn() );
    	                                }
    	                                catch (Exception e)
    	                                {
    	                                    errors.Add( e );
    	                                }
    	                                finally
    	                                {
    	                                    sem.Signal();
    	                                }
    	                            }
    	                            , ctx.Token );
    	                    }
    	                    sem.Signal();
    	                    await sem.WaitAsync( ctx.Token );
                            if(errors.Count>0)
                                observer.OnError(new AggregateException(errors));
                            else
                                observer.OnCompleted();
    	                }
    	                  , ctx.Token );
    
    	            return Disposable.Create( () => ctx.Cancel() );
    	        } );
    	}
    
        #region hosts
    
  
       
        public static string [] Hosts = new [] { "google.com" }
        #endregion
    
    
        public static void Main()
    	{
    		var s = System.Diagnostics.Stopwatch.StartNew();
    		
    		var rate = 25;
    
    	    var n = Hosts.Length;
    
            var expectedTime = n/rate;
    
    	    IEnumerable<Func<Task<IPHostEntry>>> dnsTaskFactories = Hosts.Defer( async host =>
    	    {
    	        try
    	        {
    	            return await Dns.GetHostEntryAsync( host );
    	        }
    	        catch (Exception e)
    	        {
                    throw new Exception($"Can't resolve {host}", e);
    	        }
    	    } );
    
    	    IObservable<IPHostEntry> results = RateLimit( dnsTaskFactories, rate );
    
            results
                .Subscribe( result =>
    	        {
    	            Console.WriteLine( "result " + DateTime.Now + " " + result.AddressList[0].ToString() );
    	        },
                onCompleted: () =>
                {
                    Console.WriteLine( "Completed" );
    
                    PrintTimes( s, expectedTime );
                },
                onError: e =>
                {
                    Console.WriteLine( "Errored" );
    
                    PrintTimes( s, expectedTime );
    
                    if (e is AggregateException ae)
                    {
                        Console.WriteLine( e.Message );
                        foreach (var innerE in ae.InnerExceptions)
                        {
                            Console.WriteLine( $"     " + innerE.GetType().Name + " " + innerE.Message );
                        }
                    }
                    else
                    {
                            Console.WriteLine( $"got error " + e.Message );
                    }
                }
    
                );
    
            Console.WriteLine("Press enter to exit");
    	    Console.ReadLine();
    	}
    
        private static void PrintTimes(Stopwatch s, int expectedTime)
        {
            Console.WriteLine( "Done" );
            Console.WriteLine( "Elapsed Seconds " + s.Elapsed.TotalSeconds );
            Console.WriteLine( "Expected Elapsed Seconds " + expectedTime );
        }
    }
