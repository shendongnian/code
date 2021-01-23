    /// <summary>
    /// A <see cref="IPlatformProvider"/> implementation for the XAML platfrom (Silverlight).
    /// </summary>
    public class XamlPlatformProvider : IPlatformProvider {
        private Dispatcher dispatcher;
        public XamlPlatformProvider() {
           dispatcher = System.Windows.Deployment.Current.Dispatcher;
        }
        private void validateDispatcher() {
            if (dispatcher == null)
                throw new InvalidOperationException("Not initialized with dispatcher.");
        }
        /// <summary>
        ///  Executes the action on the UI thread asynchronously.
        /// </summary>
        /// <param name = "action">The action to execute.</param>
        public Task OnUIThreadAsync(System.Action action) {
            validateDispatcher();
            var taskSource = new TaskCompletionSource<object>();
            System.Action method = () => {
                try {
                    action();
                    taskSource.SetResult(null);
                } catch (Exception ex) {
                    taskSource.SetException(ex);
                }
            };
            dispatcher.BeginInvoke(method);
            return taskSource.Task;
        }
    }
