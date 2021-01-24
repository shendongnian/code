        Mock<MailMessage> mailMessageMock = new Mock<MailMessage>();
        MailMessage message = (MailMessage)mailMessageMock.Setup(m => new     MailMessage()).Returns(mailMessageMock.Object);
        Mock<SmtpClient> smtpClientMock = new Mock<SmtpClient>();
        smtpClientMock.Setup(s => new SmtpClient()).Returns(smtpClientMock.Object);
        EmailService emailService = new EmailService(mailMessageMock.object,smtpClientMock.object);
