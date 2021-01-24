        private async Task ResumeAfterSearchPerformed(IDialogContext context, IAwaitable<object> result)
        {
            
            var msg = await result;            
            var userSearchString = msg.ToString();
            if (userSearchString.Equals("searchCompleted", StringComparison.InvariantCultureIgnoreCase))
            {                
                context.Wait(MessageReceived);
            }
            else
            {
                // At this point send the message back to LUIS MessageReceived 
                // method to re-identify the intent and trigger the method
                Activity myActivity = (Activity)context.Activity;
                myActivity.Text = userSearchString;
                await MessageReceived(context, Awaitable.FromItem(myActivity));
            }
        }
