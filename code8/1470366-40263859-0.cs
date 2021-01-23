     if (result.Entities.Count == 0)
        {
            PromptDialog.Text(context, AfterUserInputSymbol, "Message to the user", "Try again message", 2);
            // The following line shouldn't be here
            result.Entities[0].Entity = userSymbol;                
        }
        //here you should put an else
       else 
       {
        context.Wait(MessageReceived);
       }
