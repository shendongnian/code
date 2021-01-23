    public async Task<ActionResult> AsyncQuery()
    {
        var task = GetAsyncDepartments();
        Debug.WriteLine("Do some stuff here");
        await task;
        return View("Index");
    }
