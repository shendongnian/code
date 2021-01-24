    public void Process(Action<int> callBack)
    {
        SetTimer();
        Console.WriteLine("The application started ");
        if (timer != null)
            timer.Disposed += (o, e) => callBack(counter);
    }
