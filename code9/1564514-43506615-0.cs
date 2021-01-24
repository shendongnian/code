    private async Task ResumeAfterBuildSatisfactionForm(IDialogContext context, IAwaitable<SatisfactionQuery> result)
    {
        var msg = context.MakeMessage();
        var stateClient = new StateClient(new Uri(msg.ServiceUrl));
        stateClient.BotState.DeleteStateForUser(msg.ChannelId, msg.From.Id);
    }
