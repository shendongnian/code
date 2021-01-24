    using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var token = new CancellationToken();
                    var botData = scope.Resolve<IBotData>();
                    await botData.LoadAsync(token);
    
                    var stack = scope.Resolve<IDialogStack>();
                    stack.Reset();
    
                    botData.UserData.Clear(); 
                    botData.ConversationData.Clear();
                    botData.PrivateConversationData.Clear();
                    await botData.FlushAsync(token);
    
                    var botToUser = scope.Resolve<IBotToUser>();
                    await botToUser.PostAsync(message.CreateReply($"{timerMessage}  Conversation aborted."));
                }
