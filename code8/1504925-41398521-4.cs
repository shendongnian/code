    public ActionResult GetEmployeeInformation(string objdata)
    {
        Customerproductdto objGetEmpData = null;
        try
        {
            objGetEmpData = _DataService.SearchEmplByNumber(objdata);
        }
        catch (Exception ex)
        {
            logger.Error(ex);
        }
        if(objGetEmpData!=null)
        {
            var h= RenderRazorViewToString("_Empinformation", objGetEmpData);
            return Json(new { status="found",resultHtml=h});
        }
        return Json(new { status="notfound"});
    }
