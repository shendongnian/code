    public class BindingListener : DefaultTraceListener`
    {
        public BindingListener()
        {
			PresentationTraceSources.Refresh();
			PresentationTraceSources.DataBindingSource.Listeners.Add(this);SourceLevels.Error;
        }
        public override void WriteLine(string message){...}
    }
