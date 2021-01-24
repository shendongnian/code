        //From Controller
        public ActionResult SomeMethod()
        {
           var states = GetAllStates();
           var model = <enter movies query here>;
           ViewBag.StatesList = GetSelectListItems(states);
           //This will be accessible in the view now
    
           return View(model);
        }
    
        //In View:
        @{
            List<SelectListItem> StatesList =  (List<SelectListItem>)ViewBag.StatesList; // Can now use this variable to bind to DropDownList, etc.
         }
