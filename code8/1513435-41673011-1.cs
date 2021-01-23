    [Route("send")]
    [HttpPost]
    public IHttpActionResult SendEmail(MyViewModel model)
    {
        Office365MailSender ms = new Office365MailSender();
        EmailDto email = new EmailDto(model.Address, model.Subject, model.Body);
        ms.Send(email);
        return this.Ok();
    }
