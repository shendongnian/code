    [RequireLogin]
    public ActionResult Report_Performance(string id)
    {
        DateTime newDate = DateTime.Now.Date.AddMonths(-1);
        if (id != null)
            newDate = DateTime.Parse(id);
        var aVar = Models.Reporting.ListingStatsReportingViewModel.GetStats(userCurrentService.CompanyId.Value, Models.Reporting.DateTimePeriod.Monthly, newDate);
        
        //This will make sure that the model returns the correct value of the property as a string.
        aVar.SelectedDateString = id;
        return this.View(aVar);
    }
