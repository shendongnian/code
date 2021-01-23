    public async Task<string> GetData()
    {
        using(var timer = new TimerContext())
            return await _service.GetData();
    }
