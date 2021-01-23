    db.Notifications
        .Where(n => n.AppointmentId == 1)
        .OrderBy(n => n.Id)
        .Select(n => new
        {
            Id = n.Id,
            Message = n.Message
        }).ToList();
