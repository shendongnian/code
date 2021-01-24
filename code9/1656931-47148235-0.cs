    [Serializable]
        public class AddFamilyMembersDialog : IDialog<object>
        {
            List<Family> _familyMembers = new List<Family>();
    
            public Task StartAsync(IDialogContext context)
            {
                context.Wait(MessageReceivedAsync);
    
                return Task.CompletedTask;
            }
    
            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
            {
                PromptAddMembers(context);
            }
    
            private void PromptAddMembers(IDialogContext context)
            {
                PromptDialog.Text(context, AfterPromptAdd, "Would you like to add more family members?", null, 1);
            }
    
            private async Task AfterPromptAdd(IDialogContext context, IAwaitable<string> result)
            {
                var yesno = await result;
    
                if (yesno.ToLower() == "yes")
                {
                    await context.Forward(FormDialog.FromForm(Family.BuildForm), AfterAdded, null, CancellationToken.None);
                }
                else
                {
                    //_familyMembers contains everyone the user wanted to add
                    context.Done(true);
                }
            }
    
            private async Task AfterAdded(IDialogContext context, IAwaitable<Family> result)
            {
                var member = await result;
                if (member != null)
                    _familyMembers.Add(member);
    
                PromptAddMembers(context);
            }
    
            [Serializable]
            public class Family
            {
                [Prompt("What is their name?")]
                public string PersonName { get; set; }
    
                [Prompt("How old are they?")]
                public string PersonAge { get; set; }
    
                [Prompt("How are they related to you?")]
                public string PersonRelation { get; set; }
                
                public static IForm<Family> BuildForm()
                {
                    return new FormBuilder<Family>()
                    .AddRemainingFields()
                    .Build();
                }
            }
    
        }
