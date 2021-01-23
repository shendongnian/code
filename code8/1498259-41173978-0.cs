    [TestFixture]
    public class EmailReportSenderTests
    {
        [Test]
        public void EmailReportSender_Send_CallsValidateContent()
        {
            var mock = new Mock<ISender>();
            mock.Setup(m => m.Send()).Verifiable();
            var sender = new EmailReportSender(mock.Object);
            sender.Send();
            mock.Verify(m => m.ValidateContent());
        }
    }
