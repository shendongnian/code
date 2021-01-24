            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
            {
                var activity = await result as Activity;
                if (activity != null && activity.Text.ToLower().Contains(username))
                {
                    await context.PostAsync($"Shut up {username}!");
                }                      
                context.Wait(MessageReceivedAsync);
            }
