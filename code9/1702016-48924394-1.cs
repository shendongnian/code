    public class ExitScorable : ScorableBase<IActivity, string, double>
    {
        private readonly IDialogTask task;
    
        public ExitScorable(IDialogTask task)
        {
            SetField.NotNull(out this.task, nameof(task), task);
        }
    
        protected override async Task<string> PrepareAsync(IActivity activity, CancellationToken token)
        {
            var message = activity as IMessageActivity;
    
            if (message != null && !string.IsNullOrWhiteSpace(message.Text))
            {
                if (message.Text.ToLower().Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    return message.Text;
                }
            }
    
            return null;
        }
    
        protected override bool HasScore(IActivity item, string state)
        {
            return state != null;
        }
    
        protected override double GetScore(IActivity item, string state)
        {
            return 1.0;
        }
    
        protected override async Task PostAsync(IActivity item, string state, CancellationToken token)
        {
            var message = item as IMessageActivity;
    
            if (message != null)
            {
                var settingsDialog = new ExitDialog();
    
                var interruption = settingsDialog.Void<object, IMessageActivity>();
    
                this.task.Call(interruption, null);
    
                await this.task.PollAsync(token);
            }
        }
    
        protected override Task DoneAsync(IActivity item, string state, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
