    try
    {
        var model = new VisitViewModel();
        model = await visitAPI.GetVisit(clientID, visitID);
        return View(model);
    }
    catch (Exception ex)
    {
         Response.StatusCode = (int)HttpStatusCode.BadRequest;
         return null;
    }
                 
