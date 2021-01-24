    SemaphoreSlim semaphore = new SemaphoreSlim(1,1);    
    public async Task<ActionResult> Create([Bind(Include = "Value1,Value2,Id")] Test test)
    {
        await semaphore.WaitAsync().ConfigureAwait(false);
        if (ModelState.IsValid)
        {
            db.AuditTests.Add(test);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
        semaphore.release();
        return new EmptyResult();
    }
