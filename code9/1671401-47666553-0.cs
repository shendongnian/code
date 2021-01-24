    public FirstController: Controller
    {
        [HttpPost]
        public ActionResult SomeLogic(Model model)
        {
            return view();
        }
    }
    public SecondController: Controller
    {
        [HttpPost]
        public ActionResult SomeLogic(Model model)
        {
            return view();
        }
    }
