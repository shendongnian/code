            public Task StartAsync(IDialogContext context)
    		{
    			context.PostAsync($"Hi!");
    			PromptDialog.Choice(context,
    				HandleLang,
    				new[] { "English", "Espanol"},
    				"Please select a language:",
    				"I didn't get that");
    			return Task.CompletedTask;
    		}
    
    		
    		public async Task HandleLang(IDialogContext context, IAwaitable<string> result)
    		{
                string lang = await result as string;
                switch (lang)
    			{
    				case "English":
    					Strings.Culture = new CultureInfo("en-US");
    					break;
    				case "Espanol":
    					Strings.Culture = new CultureInfo("es-ES");
    					break;
    				default:
    					break;
    			}
                ... do whatever here
    		}
