    public ActionResult ExportReportToExcel(string X, string Y, string Z)
    {
        // other stuff
        var customer = _authenticationService.CurrentCustomer;
        if (customer == null)
            return new LmsHttpUnauthorizedResult();
        try
        {   
            // other stuff
            return null; // this returns null value instead of expected JSON
        }
        catch (Exception ex)
        {
            return Redirect(TempData["PDFPrevUrl"].ToString());
        }
    } 
