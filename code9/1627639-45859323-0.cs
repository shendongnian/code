    public class DebugActivityLogger : IActivityLogger
        {
            public async Task LogAsync(IActivity activity)
            {
                Debug.WriteLine($"From:{activity.From.Id} - To:{activity.Recipient.Id} - Message:{activity.AsMessageActivity()?.Text}");
            }
        }
