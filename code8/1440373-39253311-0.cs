    // Separate the emailTo string into a list of email addresses
    List<string> emailAddresses = new List<string>();
        int startingIndex = 0;
        while (startingIndex < emailTo.Length)
        {
            int commaIndex = emailTo.IndexOf(",", i);
            if (commaIndex != -1)
            {
                //Extract the email address
                string emailAddress = emailTo.Substring(startingIndex, commaIndex - startingIndex);
                
                // Remove the space following the comma
                if (emailAddress.Substring(0, 1) == " ")
                {
                    emailAddress = emailAddress.Substring(1, emailAddress.Length - 1);
                }
                i = startingIndex + 1;
                result.Add(emaiAddress);
            }
        }
    
    // Add each email address to the message's recipients
    foreach(string emailAddress in emailAddresses)
    {
        mail.To.Add(emailAddress);
    }
