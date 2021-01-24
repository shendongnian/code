    [Route("SomeAction")]    
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult MyAction1()
    {
        MyMethod()
        return View("MyAction");
    }
    
    [Route("~/OtherArea/some-route/SomeAction")]
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult MyAction2()
    {
        MyMethod();
        return View("MyAction");
    }
    private MyMethod(){
     ....
    }
