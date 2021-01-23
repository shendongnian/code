    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id) {
        var name = HttpContext.Current.User.Identity.Name.ToString();
        clsHost HostDAL = new clsHost();
        vw_Host vw_host = await HostDAL.GetByIdAsync(id);
        string actionStatus = HostDAL.Delete(vw_host, name);
    
        TempData["msgHost"] = actionStatus;
        return RedirectToAction("Display");
    }
