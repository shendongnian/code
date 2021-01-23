    [Authorize]
    [HttpPost]
    public async Task<JsonResult> UpdateDisplayName(string displayname) {
        bool status = _myProfileService.UpdateDisplayName(displayname, sessionAdapterService.Id);
    
        if (status)
            sessionAdapterService.DisplayName = displayname;
    
        return Json(new { status = status, displayname = displayname }, JsonRequestBehavior.AllowGet);
    }
