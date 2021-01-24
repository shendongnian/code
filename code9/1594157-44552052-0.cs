    private async Task AfterForm(IDialogContext context, IAwaitable<StandardInfoForm> result)
    {
        var state = await result;
       
        if (!string.IsNullOrEmpty(state.ApplicationName) && !string.IsNullOrEmpty(state.PojectName))
        {
            state.ReportRequest = "application,project";
        }
        else if (!string.IsNullOrEmpty(state.ApplicationName))
        {
            state.ReportRequest = "application";
        }
        else (!string.IsNullOrEmpty(state.PojectName))
        {
            state.ReportRequest = "project";
        }
    }
         
