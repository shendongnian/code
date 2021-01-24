    if (Session["ModelStateSummary"] != null)
    {
        var stateSummaries = (List<ModelStateSummary>)Session["ModelStateSummary"];
        ModelState.Merge(stateSummaries.ToModelState()); 
    }
