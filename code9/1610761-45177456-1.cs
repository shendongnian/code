    public class MessageViewModel
    {
        public List<string> myArray = new List<string>();
        [Required]
        public string name { get; set; }
        [Required]
        public string age { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult IndexStackOverflow900(MessageViewModel mvm)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
                //you can narrow it down to which field caused the error by inspecting ModelState
                //List<ModelErrorCollection> errors = controller.ModelState.Select(x => x.Value.Errors)
                //           .Where(y => y.Count > 0)
                //           .ToList();
                ModelState.AddModelError("name", "name is required");
                ModelState.AddModelError("age", "age is required");
            }
            FactorCode(mvm);
            return View(mvm);
        }
        public ActionResult IndexStackOverflow900()
        {
            MessageViewModel mvm = new MessageViewModel();
            FactorCode(mvm);
            return View(mvm);
        }
        public void FactorCode(MessageViewModel mvm)
        {
            mvm.myArray.Add("name");
            mvm.myArray.Add("age");
        }
