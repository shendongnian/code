    reference.GetReference("users")
             .GetValueAsync().ContinueWith(task => {
                 if (task.IsFaulted) {
         
                 }
                 else if (task.IsCompleted) {          
                   // Do something with snapshot...
                 }
      });
