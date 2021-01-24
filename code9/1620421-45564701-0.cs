    public class CancelScorable : ScorableBase<IActivity, string, double>
    {
        private readonly IDialogTask task;
        public CancelScorable(IDialogTask task)
        {
            SetField.NotNull(out this.task, nameof(task), task);
        }
        protected override async Task<string> PrepareAsync(IActivity activity, CancellationToken token)
        {
            // Accessing info, for example here UserData:
            var userData = await activity.GetStateClient().BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
            // ... add your treatment
            return null;
        }
        // ...
    }
