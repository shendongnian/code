    public ActionResult Edit(int id)
    {
       var m = db.Members.Find(id);
       var vm = new CreateMemeberVm() { FirstName = m.FirstName, SelectedTeamId=m.TeamId};
       vm.Teams = GetTeamItems();
       return View(vm);
    }
