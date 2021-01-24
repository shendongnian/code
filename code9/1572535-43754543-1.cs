    var message = activity.AsMessageActivity();
    var text = message.Text;
    if (!Int32.TryParse(text, out int number))
    {
        // reply that there is no number;
        return;
    }
    var HighScores = (from UserLog in DB.NYPCourses
        where (UserLog.Course != null) && (UserLog.CutOffPoint == number)
        select UserLog)
        .OrderBy(x => x.Course)
        .ToList();
