    foreach (var recipient in subscription.Recipients)
    {
        switch (recipient.ReceivingMethod)
        {
            case ReceivingMethod.To:
                mail.To.Add(recipient.EMailAdress);
                break;
            case ReceivingMethod.Copy:
                mail.Copy.Add(recipient.EMailAdress);
                break;
            case ReceivingMethod.BlindCopy:
                mail.BlindCopy.Add(recipient.EMailAdress);
                break;
        }
    }
