    var query = ctx.UserAlerts.Include(x=>x.DocumentType).Where(x => x.UserId == userId).ToList();
    var alerts = query.Select(u => new AlertConfigVM
                {
                    UserId = u.UserId,
                    Destination = u.AlertDestination,
                    TypeofAlert = u.TypeofAlert,
                    HourInterval = u.IntervalAsHours,
                    DocumentTypeName= u.DocumentType != null 
                                      ? u.DocumentType.Name != null 
                                          ? u.DocumentType.Name 
                                          : string.Empty 
                                      : string.Empty
                }).ToList();
