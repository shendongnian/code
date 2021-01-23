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
           return PartialView("_Empinformation", objGetEmpData);
        return Content("No information found for the employee");
    }
