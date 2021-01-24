    while (true)
    {
        while (!messageQueue.IsEmpty)
        {
            //Post to server
        }
        SpinWait.SpinUntil(() => !messageQueue.IsEmpty);
    }
