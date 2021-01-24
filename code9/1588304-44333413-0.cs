            public ActionResult SearchTable(string firstNamedInsured)
            {
                //Use the parameter in the model or any where
                var states = GetAllStates();
                var model = new ProjectClearanceApp.Models.ProjectViewModel();
    
                model.States = GetSelectListItems(states);
                model.Projects = from m in db.Projects select m;
    
                return PartialView("~/Views/Projects/_ClearedProjects.cshtml", model);
            }
