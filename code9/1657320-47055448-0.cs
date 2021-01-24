    StringBuilder infoMessage = new StringBuilder();
    foreach (string element in form.InfoMessages)
    {
        infoMessage.AppendLine("<a>" + element + "</a><br/>");
    }
    mailItem2.HTMLBody = string.Format("{0} <br/> {1}",infoMessage,mailItem2.HTMLBody);
