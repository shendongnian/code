    public async Task MessageReceived(IDialogContext context, 
            IAwaitable<Connector.IMessageActivity> toBot)
            {
                try
                {
                    var toBotText = (toBot != null ? (await toBot).Text : null);
                    var stepInput = toBotText == null ? "" : toBotText.Trim();
                    //rest of the method.
