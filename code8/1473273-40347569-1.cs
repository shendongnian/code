    [TestClass]
    public class MailTests {
        [TestMethod]
        public void MailSendWithRightModel() {
            //Arrange
            var mockService = new Mock<IEmailService>();
            var controller = new HomeController(mockService.Object);
            var email = EmailModel();
            email.Name = EmailSetter.DefaultName;
            email.Email = EmailSetter.DefaultName;
            email.Topic = EmailSetter.DefaultTopic;
            email.Massage = EmailSetter.DefaultMassage;
            //Act
            controller.Contact(email.Object);
            //Assert
            mockService.Verify(m => m.Send(email.Object));
        }
    }
