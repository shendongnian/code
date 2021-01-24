    protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            var message = await item;
            if (string.IsNullOrEmpty(message.Text))
            {
                dynamic value = message.Value;
                if (value == null)
                {
                    // empty message - show help, error etc.
                }
                dynamic cardName = value.CardName;
                // check the name, respond with the wanted card ...
            }
            else
            {
                // process as usual
                await base.MessageReceived(context, item);
            }
        }
