    public List<UserActivity> GetUserActivity(Guid userId)
    {
        MyUser user = _dbContext.MyUsers.FirstOrDefault(u => u.Id.Equals(userId));
        TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(user.TimeZoneId);
    
        var activities = _dbContext.UserActivity
                                   .Where(ua => ua.UserId.Equals(userId))
                                   .OrderByDescending(ua => ua.ActivityTime)
                                   .Take(20)
                                   .ToList();
        return activities.Select(a => new UserActivity
        {
            UserId = a.Userid,
            ActivityTitle = a.ActivityTitle,
            ActivityTime = TimeZoneInfo.ConvertTimeFromUtc(a.ActivityTime, userTimeZone)
        }).ToList();
    }
