    [HttpGet]
    public async Task<IHttpActionResult> ActionMethod()
    {
        var httpActionResult = Ok(); //some work instead it
        new Thread(() =>
        {
            Thread.Sleep(500);
            Environment.Exit(1);
        }).Start();
        return httpActionResult;
    }
