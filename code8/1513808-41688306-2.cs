    FirebaseDatabase.DefaultInstance
      .GetReference("users")
      .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
          // Handle the error...
        }
        else if (task.IsCompleted) {          
          // Do something with snapshot...
        }
      });
