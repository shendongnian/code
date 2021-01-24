    public ActionResult Create()
    {
       var vm = new CreateMemeberVm();
       vm.Teams = GetTeamItems();
       return View(vm);
    }
    public List<SelectListItem> GetTeamItems()
    {
        using (var db = new EF_Model.DigikalaHREntities())
        {
            return db.Teams
                     .Select(a=>new SelectListItem { 
                                                     Value=a.TeamId.ToString(),
                                                     Text=a.TeamName
                                                   })
                      .ToList();
        }
    }
