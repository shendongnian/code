    private const Timespan c_maxTime = new Timespan(0, 0, 10);
    private static DateTime? s_lastValidEvent;
    private static object s_lockObject = new Object();
    private static void QueueRequestChanged()
    {
         lock (s_lockObject)
         {
              if (!s_lastValidEvent.HasValue || (DateTime.Now - s_lastValidEvent.Value) > c_maxTime)
              {
                  // Do whatever the event is supposed to trigger
                  s_lastValidEvent = DateTime.Now;
              }
         }
    }
