    List<UserListingVM> userInfo = _context.Users.Select(u => new UserListingVM()
        {
            Id = u.Id,
            Email = u.Email
        }).ToList();
     List<string> userEmails = userInfo.Select(u => u.Email).ToList();
    Log.Debug("Displaying Users {@Users}", userEmails);
