    var query = db.Users
        .Where(user => user.UserName == name)
        .SelectMany(user => user.Submissions)
        .Where(subm => (subm as CallSubmission).PickUp >= startDate
            || (subm as WebSubmission).SubmissionDate >= startDate);
