    private string ExtractMailTo(string html, string domainToExclude)
    {
        try
        {   //Searches for mailTos with regEx
            //If user didn't pass any domain we will just ignore it
            //and pick up the last mailTo.
            bool deleteDomainUser = (!string.IsNullOrEmpty(domainToExclude)
                || !string.IsNullOrWhiteSpace(domainToExclude));
                
            var mailTos = new List<String>();
            string pattern = @"mailto\s*:\s*([^""'>]*)";
            foreach (Match match in Regex.Matches(html, pattern))
                mailTos.Add(match.Groups[1].Value);
                
            if(deleteDomainUser)
                //We search for the domain concreted by the user
                //and we delete it from the mailTos List
                mailTos.RemoveAll(doms => doms.Contains(domainToExclude));
            var last = mailTos.Last();
            return last;
        }
        catch (Exception ex)
        {
            string message = "A problem ocurred parsing the e-mail body searching for MailTos. \n" 
                    + ex.Message;
            throw new Exception(message, ex);
        }
    }
