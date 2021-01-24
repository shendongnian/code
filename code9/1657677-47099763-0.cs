        private async Task QnADialog(IDialogContext context, IAwaitable<object> result)
        {
            var activityResult = await result as Activity;
            var query = activityResult.Text;
            var reply = activityResult.CreateReply();
            var qnaResult = QnaApi.GetFirstQnaAnswer(query);
            if (qnaResult == null)
            {
                string message = $"Sorry, I did not understand. Please reformulate your question";
                reply.Text = message;
            }
            else
            {
                string message = qnaResult.answers[0].answer;
                
            }
            Model.qnamakerbotdataEntities DB = new Model.qnamakerbotdataEntities();
            // Create a new UserLog object
            Model.UserLog NewUserLog = new Model.UserLog();
            // Set the properties on the UserLog object
            NewUserLog.Channel = reply.ChannelId;
            NewUserLog.UserID = reply.From.Id;
            NewUserLog.UserName = reply.From.Name;
            NewUserLog.created = DateTime.UtcNow;
            NewUserLog.Message = reply.Text;
            await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
        }
