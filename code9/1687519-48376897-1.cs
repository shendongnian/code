    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
    
            //call the first formflow dialog
            var form = new FormDialog<FFDialog1>(new FFDialog1(), FFDialog1.BuildForm, FormOptions.PromptInStart, null);
            context.Call(form, ResumeAfterFirstFFDialog);
        }
    
        private async Task ResumeAfterFirstFFDialog(IDialogContext context, IAwaitable<object> result)
        {
            var dialog = await result as FFDialog1;
    
            //call the second formflow dialog according to the result of first one.
            if (dialog.Test != null && dialog.Description != null)
            {
                var form = new FormDialog<FFDialog2>(new FFDialog2(), FFDialog2.BuildForm, FormOptions.PromptInStart, null);
                context.Call(form, ResumeAfterSecondFFDialog);
            }
        }
    
        private async Task ResumeAfterSecondFFDialog(IDialogContext context, IAwaitable<object> result)
        {
            //get result of formflow dialog 2.
            var dialog = await result as FFDialog2;
    
            await context.PostAsync("Work is done!");
    
            context.Wait(MessageReceivedAsync);
        }
    }
