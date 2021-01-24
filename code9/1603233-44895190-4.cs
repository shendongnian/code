    public PeopleController : BaseController
    {
        [HttpPost]
        public ActionResult Create(PersonModels person)
        {
            try
            {
                // TODO: Add insert logic here
                //Adding to database and holding the response in the viewbag.
                string strInsertion = ConnectionModels.insertPerson(person);
                TempData["GlobalMessage"] = new GlobalMessage{ AlertType = AlertType.Info, Message = "You have successfully added a new person" }
    
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
