    [HttpPost]
    public ActionResult Index(int firstInt = 0, int secondInt = 0, int thirdInt = 0)
    {
        int sum = firstInt + secondInt + thirdInt;
        ViewBag.result = sum;
        return View();
    }
