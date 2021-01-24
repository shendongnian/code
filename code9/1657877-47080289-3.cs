    public JsonResult IsClientExist(string Email)
    {
        var r = DoesEmailExist(Email);
        return Json(!r, JsonRequestBehavior.AllowGet);
    }
