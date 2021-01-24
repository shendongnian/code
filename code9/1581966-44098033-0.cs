    static object traceSync = new object( );
    static int traceMessageNumber;
    internal static void Emit( this TraceSource traceSource, TraceEventType eventType, string message, params object[ ] args )
    {
      try
      {
        lock ( traceSync )
        {
          var msgNum = Interlocked.Increment( ref traceMessageNumber );
          if ( traceSource.Switch.ShouldTrace( eventType ) )
          {
            //--> format your message like you want...
            var msg = YourMessageFormatter( msgNum, message, args );
    
            foreach ( TraceListener listener in traceSource.Listeners )
            {
              try
              {
                listener.WriteLine( msg );
                listener.Flush( );
              }
              catch { }
            }
          }
        }
      }
      catch
      {
        //--> maybe we'll write an event log entry?
      }
    }
