    public class UnitTestDummySender : IMailSender
    {
        public string fromAddressIShouldGet;
        public string toAddressIShouldGet;
        public string bodyIShouldGet;
        public void Send(string from, string to, string body)
        {
            // check to make sure the arguments passed in match those properties
        }
    }
