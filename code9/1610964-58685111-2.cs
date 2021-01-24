    [FunctionName("MyFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        [Binding.FromBody] dynamic data) // or you can change 'dynamic' to some class
    {
        string username = data?.username;
        ...
    }
