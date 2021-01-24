    var invites = db.invites.Include(i => i.Members).Where(i => i.Members.Any(m => m.IsAttending && m.MemberID == memberId)).ToList(); // db query
    invites = invites.Select(i =>
        new Invite
        {
            DateTime = i.DateTime,
            InviteID = i.InviteID,
            Subject = i.Subject,
            Members = i.Members.Where(m => m.IsAttending && m.MemberID == memberId).ToList()
        }).ToList(); // this removes other members (in memory)
     return invites;
