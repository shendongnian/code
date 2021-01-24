    var getTask = FirebaseDatabase
       .DefaultInstance
       .GetReference ("MA1")
       .Child ("Zaehler") .GetValueAsync();
    
    yield return new WaitUntil(() => getTask.IsCompleted || getTask.IsFaulted);
    
    if (getTask.IsCompleted) {
      Debug.Log(getTask.Result.Value.ToString());
    }
