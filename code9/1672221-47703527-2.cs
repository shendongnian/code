    [Serializable]
    public class CustomPromptInt64 : PromptInt64
    {
        public CustomPromptInt64(string prompt, string retry, int attempts, long? min = null, long? max = null) 
                : base(prompt, retry, attempts, null, min, max)
        {
        }
        protected override bool TryParse(IMessageActivity message, out long result)
        {
            if(Int64.TryParse(message.Text, out result))
            {
                return (result >= this.Min && result <= this.Max);
            }
            return false;
        }
    }
