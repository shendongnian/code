    public async Task<IViewComponentResult> InvokeAsync(int? clientID, int? visitID)
    {
        var model = new VisitViewModel();
        model = await visitAPI.GetVisit(clientID, visitID);
        return View(model);    
    }
