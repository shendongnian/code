    public void StartProducingItems()
    {
        Task.Run(() =>
        {
            while (true)
                _queue.Add(_random.Next());
        });
    }
