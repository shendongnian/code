    [TestMethod()]
    public void SendMailTest()
    {
        string subject ="subject";
        string body = "body";
        string recipient = "test@test.com";
        Message result = null;
            
        try
        {
            result = MailTools.SendMail(subject, body, recipient);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        } 
        result.ShouldNotBeNull();
    }
