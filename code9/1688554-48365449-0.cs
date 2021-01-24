        static void FireAndForget(this Task task)
        {
            if (task.IsCompleted) return;
            task.ContinueWith(t =>
            {
                try
                { // show it that we checked
                    GC.KeepAlive(t.Exception);
                } catch { }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
