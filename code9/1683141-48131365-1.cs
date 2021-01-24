    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckValidMail_ZeroRecipientens() {
        //Arrange
        var mockRecpients = new Mock<Microsoft.Office.Interop.Outlook.Recipients>();
        mockRecpients.Setup(_ => _.Count).Returns(0);
        var mockMailItem = new Mock<Microsoft.Office.Interop.Outlook.MailItem>();
        mockMailItem.Setup(_ => _.Recipients).Returns(mockRecpients.Object);
        var mailItem = mockMailItem.Object;
        var mailconverter = new MailConverter(mailItem);
        
        //Act
        mailconverter.CheckValidMail();
    }
