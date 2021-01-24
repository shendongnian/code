    IList<...> existingParticipant = Context.CaseParticipants.Where(p => p.CaseId == caseId).ToList(); // Explicit executing of query
    foreach (var cp in existingParticipant)
    {
        var ncp = caseParticipantList.First(a => a.Id == cp.Id);
        cp.IsIncompetent = ncp.IsIncompetent;
        cp.IsLeave = ncp.IsLeave;
        cp.SubstituteUserId = ncp.IsPresent ? null : ncp.SubstituteUserId;
    }
    var withSubs = existingParticipant.Where(c => c.SubstituteUserId != null).ToList(); // Working in memory on list
