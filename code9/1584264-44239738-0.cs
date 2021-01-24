    public ActionResult MultiThread()
    {
     HotelService svc = new HotelService();
     var resp = new List<TestPnrHeaderResponse>();
     var tasks = Enumerable.Range(0, 5).Select(i => Task.Run(() => svc.TestMultiThread(i)));
     var results = await Task.WhenAll(tasks);
     return View(resp);
    }
