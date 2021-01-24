    public class MyCustomTarget : TargetWithLayout
    {
        protected override async void Write(AsyncLogEventInfo logEvent)
        {
            try
            {
               await MyLogMethodAsync(logEvent.LogEvent).ConfigureAwait(false);
               logEvent.Continuation(null);
            }
            catch (Exception ex)
            {
               logEvent.Continuation(ex);
            }
        }
    }
