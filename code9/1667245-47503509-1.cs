    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            var form = new FormDialog<Classification>(new Classification(), Classification.BuildForm, FormOptions.PromptInStart, null);
            context.Call(form, this.GetResultAsync);
    
            return Task.CompletedTask;
        }
    
        private async Task GetResultAsync(IDialogContext context, IAwaitable<Classification> result)
        {
            var state = await result;
            //TODO:
        }
    }
