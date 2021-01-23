    public static class WindowThreadHelpers
    {
        public static void LaunchWindowInNewThread<T>() where T : Window, new()
        {
            Dispatcher.CurrentDispatcher.Invoke(new ThreadStart(ThreadStartingPoint<T>));
        }
        private static void ThreadStartingPoint<T>() where T : Window, new()
        {
            SynchronizationContext.SetSynchronizationContext(
                new DispatcherSynchronizationContext(
                    Dispatcher.CurrentDispatcher));
            var win = new T();
            win.Closing += (sender, args) =>
            {
                Dispatcher.ExitAllFrames();
                win.Dispatcher.InvokeShutdown();
            };
            win.Show();
            Dispatcher.Run();
        }
    }
