    public static Task CyclicalTask(this Func<Task> task, TimeSpan waitTimeSpan,
                CancellationToken token = default(CancellationToken))
            {
                return TaskEx.Run(async () =>
                {
                    while (true)
                    {
                        token.ThrowIfCancellationRequested();
                        await task();
                        token.WaitHandle.WaitOne(waitTimeSpan);
                    }
                }, token);
            }
