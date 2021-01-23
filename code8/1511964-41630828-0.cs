    public void StoreSessionProgress(string progress)
    {
    HttpContext.Session.SetString("progress", progress);
    }
    [HttpGet]
    [Route("/getTest")]
    public string GetTest()
    {
    List<Stuff> largeCollection = GetLargeCollection();
    for(int i = 0; i < largeCollection.Count; i++)
    {
        //Do stuff
         StoreSessionProgress(i + "/" + largeCollection.Count)
    }
    return "done";
    }
    [HttpGet]
    [Route("/getTest/progress")]
    public string GetProgress()
    {
    return HttpContext.Session.GetString("progress");
    }
