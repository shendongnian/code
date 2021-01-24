    public ActionResult Index() {
         return View();
    }
    [HttpPost]
    public ActionResult Index(MyModel m) {
        int sum = m.firstInt + m.secondInt + m.thirdInt;
        ViewBag.result = sum;
        return View(m);
    }
