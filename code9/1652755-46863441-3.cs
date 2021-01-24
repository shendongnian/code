    public ActionResult GetProgramByChannel(string selection)
    {
       var model = new ProgramsModel();
       return PartialView("ProgramsByChannel", model.GetChildItemsOfChannel(selection));
    }
