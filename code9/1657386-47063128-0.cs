    [Serializable]
    [LuisModel("Luis app id", "Luis key")]
    public class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
    
        [LuisIntent("greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Hello there";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("Room.AnswerName")]
        public async Task Left(IDialogContext context, LuisResult result)
        {
            //do stuff 
            //or call new dialog to do stuff
            context.Call(new RoomReservationNameDialog(), ResumeAfterMethod);
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("Room.AnswerDateTime")]
        public async Task Right(IDialogContext context, LuisResult result)
        {
            //do stuff 
            //or call new dialog to do stuff
            context.Call(new RoomReservationDateTimeDialog(), ResumeAfterMethod);
            context.Wait(this.MessageReceived);
        }
        [LuisIntent("Room.AnswerFloor")]
        public async Task Middle(IDialogContext context, LuisResult result)
        {
            //do stuff 
            //or call new dialog to do stuff
            context.Call(new RoomReservationFloorDialog(), ResumeAfterMethod);
            context.Wait(this.MessageReceived);
        }
    }
