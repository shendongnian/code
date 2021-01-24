     private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
            {
            
            var msg = await argument;
            switch (s)
              {
                case "CONTACT_INFO_PAYLOAD" : 
                YourMethod();
                break;
              }
