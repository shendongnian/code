    var EmailBody = Item.Body.Text;
    var messages = (new[] {
        "Remote Server returned '550 No Such User Here'",
        "Remote Server returned '554 5.4.4 SMTPSEND.DNS.NonExistentDomain; nonexistent domain'",
        "Either there are no alternate hosts, or delivery failed to all alternate hosts." })
        .Select(m => Regex.Escape(m).Replace(@"\ ",@"\s+"))
        .ToArray();
    
    
    var found = messages.Any(m => Regex.IsMatch(EmailBody, m));
