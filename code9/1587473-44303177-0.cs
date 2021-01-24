    var task = Task.Run(() =>
    {
        // Takes the context of you current thread an passes it to the other thread.
        var test = MethodWithContext(HttpContext.Current);
    });
    if (!task.Wait(TimeSpan.FromSeconds(5)))
        throw new Exception("Timeout");
    
    void object MethodWithContext(HttpContext ctx)
    {
        // Now we are operating on the context of you main thread.
        return ctx.Items["Test"];
    }
