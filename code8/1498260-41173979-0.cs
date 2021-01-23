    public abstract class SenderBase
    {
        public void Send()
        {
            ValidateContent();
            CustomStuff();
        }
        protected abstract void CustomStuff();
    }
    public sealed class EmailReportSender : SenderBase
    {
        protected override void CustomStuff()
        {
            
        }
    }
    public sealed class IPhoneNotificationReportSender : SenderBase
    {
        protected override void CustomStuff()
        {
            
        }
    }
