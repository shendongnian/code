    using System;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder.Dialogs;
    using Microsoft.Bot.Builder.FormFlow;
    namespace TestChatbot.Dialogs
    {
        [Serializable]
        public class RootDialog : IDialog<object>
        {
            public async Task StartAsync(IDialogContext context)
            {
                await context.PostAsync("Welcome to the Order helper!");
                var orderFormDialog = FormDialog.FromForm(this.BuildOrderForm, FormOptions.PromptInStart);
                context.Call(orderFormDialog, this.ResumeAfterOrdersFormDialog);
            }
            private IForm<OrderSearchQuery> BuildOrderForm()
            {
                return new FormBuilder<OrderSearchQuery>()
                    .Build();
            }
            private IForm<OrderFollowUp> BuildFollowUpForm()
            {
                return new FormBuilder<OrderFollowUp>()
                    .Build();
            }
            private async Task ResumeAfterOrdersFormDialog(IDialogContext context, IAwaitable<OrderSearchQuery> result)
            {
                try
                {
                    var searchQuery = await result;
                    await context.PostAsync($"Ok. Searching for Orders with Number: {searchQuery.OrderNumber}...");
                    await context.PostAsync($"I found total of 100 Ordes");
                    int searchResultCount = 2;
                    if (searchResultCount > 1)
                    {
                        await context.PostAsync($"To get Order details, you will need to provide more info...");
                        var followUpDialog = FormDialog.FromForm(this.BuildFollowUpForm, FormOptions.PromptInStart);
                        context.Call(followUpDialog, this.ResumeAfterFollowUpDialog);
                    }
                }
                catch (FormCanceledException ex)
                {
                    string reply;
                    if (ex.InnerException == null)
                    {
                        reply = "You have canceled the operation. Quitting from the Required DWP Search";
                    }
                    else
                    {
                        reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                    }
                    await context.PostAsync(reply);
                }
            }
            private async Task ResumeAfterFollowUpDialog(IDialogContext context, IAwaitable<OrderFollowUp> result)
            {
                await context.PostAsync($"Order complete.");
                context.Done<object>(null);
            }
        }
    }
