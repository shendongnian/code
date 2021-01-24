    // receive and email and store subject name on var subject
    log.Info($"E mail with subject '{subject}' arrived.");
    // convert name and save on var newSubject
    log.Info($"Mail will be saved as '{newSubject}'.");
    // notify the beginning of the operation
    log.Info("Calling MailItemHelper.SaveMailItemToOFEFolder.");
    // notify the end of the operation
    log.Info("Mail saved successfully.");
    // notify Post in REST API
    log.Info("Sending in MailItemHelper.SendMailItemToOFEApi");
    // notify end of Post in REST API
    log.Info("MailItemHelper.SendMailItemToOFEApi sent");
