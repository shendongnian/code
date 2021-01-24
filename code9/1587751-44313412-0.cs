    public ActionResult deleteAccount()
    {
        return View();
    }
    [HttpPost]
    public ActionResult deleteAccount(int id)
    {
        try
        {
            var databaseModel = new database();
            if (databaseModel.deleteAccount(id)) 
            {
                ViewBag.AlertMsg = "Employee details deleted successfully";
            }
            return RedirectToAction("GetAllEmpDetails");
        }
        catch 
        {
            return View();
        }
}
