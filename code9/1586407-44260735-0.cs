    private long GetStakeholderId()
    {
        string currentUserId = _userManager.GetUserId(User);
        long stakeholderId;
    
        var user = _userManager.Users.Where(u => u.Email == currentUserId).FirstOrDefault();
        if (user == null)
        {
            return 0;
        }
        var stakeholder = _context.Stakeholders.Where(s => s.StakeholderId == user.IdentityId).FirstOrDefault();
        return stakeholder == null ? 0 : stakeholder.StakeholderId;
    }
