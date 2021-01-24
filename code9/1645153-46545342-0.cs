    private MyLogicClass _logic;
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "DM_Admin")] 
    public async Task<ActionResult> Users_Delete([DataSourceRequest] DataSourceRequest request, ManageUsersViewModel model)
    {
        var model = _logic.DoLogic();
        return View(model);
    }
