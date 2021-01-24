    abstract class WebhookPayload // Note this base class is not generic! 
    {
        // Common base properties here 
        public abstract void DoWork();
    }
    abstract class PersonPayload : WebhookPayload
    {
        public override void DoWork()
        {
            // your derived impl here 
        }
    }
