    [HttpPost]
    public ActionResult LeaveRequestIndex(FormCollection fmcollection)
    {
        foreach (string key in fmcollection.AllKeys)
        {
            Response.Write("Key= " + key + "  ");
            Response.Write(fmcollection[key]);
            Response.Write("<br/>");
    
        }
    
        var modal = new LeaveRequest()
            {
                UserRoles = GetRoles(),
                LoadedTableTypeName = GetTypesIdz()
            };
            return View(modal);
      }
