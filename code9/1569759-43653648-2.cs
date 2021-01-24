    [Serializable]
    public class ProfileForm
    {
        // these are the fields that will hold the data
        // we will gather with the form
        [Prompt("What is your name? {||}")]
        public string Name;
    
        // This method 'builds' the form 
        // This method will be called by code we will place
        // in the MakeRootDialog method of the MessagesControlller.cs file
        public static IForm<ProfileForm> BuildForm()
        {
            return new FormBuilder<ProfileForm>()
                    .Message("Welcome to the profile bot!")
                    .OnCompletion(async (context, profileForm) =>
                    {
                        // Set BotUserData
                        //context.PrivateConversationData.SetValue<bool>("ProfileComplete", true);
                        context.PrivateConversationData.SetValue<string>("Name", profileForm.Name);
                        // Tell the user that the form is complete
                        await context.PostAsync("Your profile is complete.");
                    })
                    .Build();
        }
    }
