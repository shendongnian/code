    tasks.Add(Task.Factory.StartNew(() =>
    {
        rs1.Process();
    }).ContinueWith((previousTask) =>
    {
        Task.Factory.StartNew(() => rs5.Process(), TaskCreationOptions.AttachedToParent);
        Task.Factory.StartNew(() => rs6.Process(), TaskCreationOptions.AttachedToParent);
    }));
