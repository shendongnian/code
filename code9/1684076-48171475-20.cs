    public class MyController : Controller
    {
        //Get
            public ActionResult MyAction()
            {
                return View(new MyModel { States = GetStateList() });
            }
        
            [HttpPost]
            public ActionResult MyAction(MyModel model)
            {
                if (!ModelState.IsValid)
                {
                    model.States = GetStateList();
                    return View(model);
                }
                   
                //do whatever you are going to do with the posted information.
                return RedirectToAction("<some view>");  //redirect after a post usually to Index.
            }
        
            private static IEnumerable<SelectListItem> GetStatesList()
            {
                var states = new List<SelectListItem>();
                foreach (var s in UsStates.ToList())
                {
                    var state = new SelectListItem { Value = s.Abbreviation, Text = s.Name, Disabled = !s.Available };
                    states.Add(state);
                }
                return states;
            }
        }
