    static void Main( string[ ] args )
    {
      var totalTime = DoSomeAsyncTasks( ).GetAwaiter( ).GetResult( );
      Console.WriteLine( "{0} Finished, duration {1}", DateTime.Now, totalTime );
      Console.WriteLine( "Press any key to exit." );
      Console.Read( );
    }
    async static Task<TimeSpan> DoSomeAsyncTasks( )
    {
      var mainStart = DateTime.Now;
      var tasks = new List<Task>( );
      for ( int i = 0; i < 10; i++ )
      {
        var id = i;
        tasks.Add( DoATask( id ) );
      }
      await Task.WhenAll( tasks );
      var mainFinish = DateTime.Now;
      return mainFinish - mainStart;
    }
    static async Task DoATask( int stepId )
    {
      var stepStart = DateTime.Now;
      Console.WriteLine(
        "{0} Starting {1} on thread {2}...",
        stepStart, stepId, Thread.CurrentThread.ManagedThreadId );
      //--> more accurately model waiting for I/O...
      await Task.Delay( TimeSpan.FromSeconds( 15 ) );
      var stepFinish = DateTime.Now;
      Console.WriteLine( "{0} Finished {1} on thread {2}, duration: {3}",
          stepStart, stepId, Thread.CurrentThread.ManagedThreadId, stepFinish - stepStart );
    }
