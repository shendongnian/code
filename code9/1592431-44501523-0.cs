    task.ContinueWith(
        taskAntecedent =>
        {
            AppCommands.SomeCommand.Execute(null, null);
        },
        System.Threading.CancellationToken.None,
        TaskContinuationOptions.None,
        TaskScheduler.FromCurrentSynchronizationContext());
