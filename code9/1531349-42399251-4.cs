    Policy timeoutPolicy = Policy.Timeout(TimeSpan.FromSeconds(10), TimeoutStrategy.Pessimistic, (context, timespan, task) => 
    {
        task.ContinueWith(t => { // ContinueWith important!: the abandoned task may very well still be executing, when the caller times out on waiting for it! 
            if (t.IsFaulted) 
            {
                logger.Error($"{context.PolicyKey} at {context.ExecutionKey}: execution timed out after {timespan.TotalSeconds} seconds, eventually terminated with: {t.Exception}.");
            }
            else
            {
               // extra logic (if desired) for tasks which complete, despite the caller having 'walked away' earlier due to timeout.
            }
        });
    });
    
    timeoutPolicy.Execute(() => BasicPublish(...));
