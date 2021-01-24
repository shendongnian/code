    public void MainThread()
    {
      var tcs = new TaskCompletionSource<object>(); // Create the signal
      Task t = Task.Run(() => ChildThread(tcs.Task)); // Pass the "receiver" end to ChildThread
      WorkA();
      WorkB();
      tcs.SetResult(null); // Send the signal
      WorkC();
    }
    public async Task ChildThread(Task workBCompleted)
    {
      WorkD();
      await workBCompleted; // (asynchronously) wait for the signal to be sent
      Need_WorkB_ToBeCompletedBeforeThisOne();
    }
