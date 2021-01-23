    List<EmailAddressStats> GetEmailAddressStats(string[] emailAddresses)
    {
        var returnList = emailAddresses.Select(e => new EmailAddressStats { Email = e })
                                       .ToList();
        // I don't know what your context is actually called so I'm just calling it MemberDatabaseContext)
        using (var dbContext = new MemberDatabaseContext())
        {
            // Query the database once with a single query to get all of the relevant members
            var membersWithEmailAddress = dbContext.Members.Where(m => emailAddresses.Contains(m.Email))
                                                           .Select(m => new { Email = m.Email, IsActive = m.IsActive })
                                                           .ToList();
            // Update the email stats by analyzing the member info in memory
            foreach (var emailStat in returnList)
            {
                emailStat.Total = membersWithEmailAddress.Count(m => m.Email == emailStat.Email);
                emailStat.Active = membersWithEmailAddress.Count(m => m.Email == emailStat.Email && m.isActive);
            }
        }
        return returnList;
    }    
