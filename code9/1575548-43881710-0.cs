     static async Task PerfromTaskAction(CancellationToken ct) {
             //StringBuilder sb = new StringBuilder();
    
             object[] arrObjects = new object[] { "SERVER1", "SERVER2", "SERVER3", "SERVER4" };
             IList<Task> tasks = new List<Task>(); // collect all tasks in single collection
             foreach( object i in arrObjects ) {
                //if (ct.IsCancellationRequested) break;
                //sb.Append(string.Format("{0}: {1}\r\n", HeavyOperation(i.ToString()),i));
                //((IProgress<string>)progressReporter).Report(string.Format("Now Checking: {0}...", i));
                tasks.Add(Task.Factory.StartNew(() => HeavyOperation(i.ToString())));
             }
             
             await Task.WhenAll(tasks).ConfigureAwait(false); // wait asynchronously for all tasks to complete
          }
