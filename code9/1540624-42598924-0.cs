    var cts = new CancellationTokenSource();
    var ct = cts.Token;
    var mtTask = Task.Run(async () =>
    {
      while (true) // Loop will be exited when cts.Cancel is called as Task.Delay will respond with an OperationCancelledException
      {
        scanner.AutoFocus();
        await Task.Delay(autoFocusInterval, ct);
       }
     }, ct);
     var result = await scanner.Scan(opts);
     cts.Cancel();
     try
     {
       await mtTask;
     }
     catch (OperationCancelledException)
     {}
     if (result != null)
     {
       MessageBox.Show("Scanned code : " + result.Text);
     }
