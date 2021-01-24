    ...
    using Microsoft.Extensions.DependencyInjection;
    ...
    [HttpPost(/*route*/)]
    public IActionResult DoWork([FromBody] string[] args)
    {
        using (var scope = Request.HttpContext.RequestServices.CreateScope())
        {
            var worker = scope.ServiceProvider.GetService<IInjectedLogic>();
            worker.doWorkAsync(args);
        }
        return NoContent();
    }
