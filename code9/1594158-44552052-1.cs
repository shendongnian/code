    public static IForm<StandardInfoForm> BuildForm()
    {
        var parser = new Parser();
        return new FormBuilder<StandardInfoForm>()
            .Message("Welcome to reporting information!!")
            .Field(nameof(ApplicationName))
            .Field(nameof(ProjectName))
            .Confirm("Would you like to confirm.Yes or No")
            .OnCompletion(async (context, state) =>
            {
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
                return new PromptAttribute("Would you like to confirm.Yes or No");
            })
            .Build();
    }
