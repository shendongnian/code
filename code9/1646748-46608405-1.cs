    Task t1 = Task.Factory.StartNew(Task1);
    t1.ContinueWith(task => 
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            textBlock1.Text = "t1 completed";
        }));
    });
    taskList.Add(t1);
    ...
    await Task.WhenAll(taskList.ToArray());
