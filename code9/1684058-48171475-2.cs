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
                if (!Model.IsValid)
                {
                    View(new MyModel { States = GetStateList() })
                }
                   
                //do whatever you are going to do with the posted information.
            }
        
            private static List<SelectListItem> GetStatesList()
            {
                var states = new List<SelectListItem>();
                states.Add(new SelectListItem { Value = "", Selected = true, Text = "State" });
                foreach (var s in UsStates.ToList())
                {
                    var state = new SelectListItem { Value = s.Abbreviation, Text = s.Name, Disabled = !s.Available };
                    states.Add(state);
                }
                return states;
            }
        }
