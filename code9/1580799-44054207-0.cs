    [LuisIntent("ProjectInfo")]
    public async Task projectInfo(IDialogContext context, LuisResult result)
    {
        PromptDialog.Text(context,AfterPromptMethod,"Please enter your project name", attempts: 100);
    }
    
    async Task AfterPromptMethod(IDialogContext context, IAwaitable<string> userInput)
    {
        var InputText = await userInput;
        string projectName = InputText.ToString();
        if (projectName!= null)
        {
            TestInfo MI = new TestInfo();
            if (MI.FindProject(projectName) == 0)
            {
                await context.PostAsync($"Project Found. What do you want to know ?");
                context.Wait(MessageReceived);
            }
            else
            {
                await context.PostAsync($"Project Not Found. Check your project name and try again.");
                this.projectInfo(context, null);
            }
        }
    }
