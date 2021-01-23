    public class myController : Controller
    {
        public ActionResult myAction()
        {
           bool switch;
           viewModel vm = new viewModel();
           if (switch)
                vm.Src = "something.jpg";
           else
                vm.Src = "somthingelse.jpg";
           return View(vm);
        }
      
    }
