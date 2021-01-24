    string[] GetUndeliverableAddresses (MimeMessage message)
    {
        var report = message.Body as MultipartReport;
    
        if (report == null)
            throw new ArgumentException ("This is not a multipart/report!");
    
        MessageDeliveryStatus status = null;
    
        for (int i = 0; i < report.Count; i++) {
            status = report[i] as MessageDeliveryStatus;
            if (status != null)
                break;
        }
    
        if (status == null)
            throw new ArgumentException ("Did not contain a message/delivery-status!");
    
        var undeliverables = new List<string> ();
        for (int i = 0; i < status.StatusGroups.Count; i++) {
            var recipient = status.StatusGroups[i]["Final-Recipient"];
            int semicolon = recipient.IndexOf (';');
    
            var undeliverable = recipient.Substring (semicolon + 1).Trim ();
            undeliverables.Add (undeliverable);
        }
    
        return undeliverables.ToArray ();
    }
