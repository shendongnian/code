    this.Dispatcher.Invoke(new Action(() =>
        {
            Thread.Sleep(5000);
            Debug.WriteLine("After Sleep");
        }));
    Debug.WriteLine("Continuation on async Thread");
