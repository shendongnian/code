    public static async Task AbortConversation(Activity message)
    {
        using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
        {
            var token = new CancellationToken();
            var botData = scope.Resolve<IBotData>();
            await botData.LoadAsync(token);
            var stack = scope.Resolve<IDialogStack>();
            stack.Reset();
            // botData.UserData.Clear(); //<-- could clear userdata as well
            botData.ConversationData.Clear();
            botData.PrivateConversationData.Clear();
            await botData.FlushAsync(token);
            var botToUser = scope.Resolve<IBotToUser>();
            await botToUser.PostAsync(message.CreateReply("Conversation aborted."));
        }
    }
