    var messagesAsReceiver = messages
        .Where(p => p.ToUserId == 8)
        .GroupBy(p => new { Me = p.ToUserId, Him = p.FromUserId })
        .ToDictionary(
            p => p.Key,
            p => p.OrderByDescending(t => t.DateSent)
                  .FirstOrDefault());
