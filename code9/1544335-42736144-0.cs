    var Attributes = db.Users.Where(u => u.UserId == PwRetreival.uId).Select(u => new { u.Name, u.UserId }).ToList().FirstOrDefault();
    
    if (Attributes != null)
    {
        user.Name = Attributes.Name;
        user.UserId = Attributes.UserId;
    }
