    static ConcurrentDictionary<int,DateTimeOffset> starts = new ConcurrentDictionary<int,DateTimeOffset>(); 
    public ActionResult Start(int workId)
    {
        starts.TryAdd(workId, DateTimeOffset.Now);
        return RedirectToAction("Index");
    }
    public ActionResult Stop(int workId)
    {
        DateTimeOffset started = DateTimeOffset.MinValue;
        if (starts.TryGet(workId, out started))
        {
           // calculate time difference
        }
        return View("Index");
    }
