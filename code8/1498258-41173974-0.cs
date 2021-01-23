    public abstract class Sender
    {
        public void Send()
        {
            ValidateContent();
            DoSend();
        }
        private void ValidateContent()
        {
            // Put validation code here
        }
        protected abstract void DoSend();
    }
    public class EmailReportSender : Sender
    {
        protected override void DoSend()
        {
            // Do stuff
        }
    }
    public class IPhoneNotificationReportSender : Sender
    {
        protected override void DoSend()
        {
            // Do stuff
        }
    }
