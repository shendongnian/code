    [TestClass]
    public class MailTests {
        [TestMethod]
        public void MailSendWithRightModel() {
            //Arrange
            var mockService = new Mock<IEmailService>();
            var controller = new HomeController(mockService.Object);
            var email = new EmailSetter().GetEmail();
            //Act
            controller.Contact(email);
            //Assert
            mockService.Verify(m => m.Send(email));
        }
    }
