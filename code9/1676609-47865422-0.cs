    protected virtual async Task DefaultWaitNextMessageAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
        {
            if (result.Answers.Count == 0)
            {
                // Here you have the query text in message.Text so:
                SendEmail email = new SendEmail();
                email.SendEmailtoAdmin(message.Text, "Email ID");
            }
            context.Done(true);
        }
