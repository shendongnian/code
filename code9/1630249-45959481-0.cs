    string phonePattern = "\"u_borrower_id\\.phone\": \"(.*?)\"";
    string emailPattern = "\"u_borrower_id\\.email\": \"(.*?)\"";
    
    Regex phoneRegex = new Regex(phonePattern);
    var phoneMatches = phoneRegex.Matches(input);
    
    Regex emailRegex = new Regex(emailPattern);
    var emailMatches = emailRegex.Matches(input);
    
    for (int i = 0; i < phoneMatches.Count; i++)
    {
        string phoneMatch = phoneMatches[i].Groups[1].Value;
        string emailMatch = emailMatches[i].Groups[1].Value;
        // Now you can add them to any collection you desire
    }
