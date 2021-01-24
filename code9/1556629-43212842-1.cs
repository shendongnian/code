     var messagesAsSender = messages
         .Where(p => p.FromUserId == 8)
         .GroupBy(p => new { Me = p.FromUserId, Him = p.ToUserId })
         .ToDictionary(
             p => p.Key,
             p => p.OrderByDescending(t => t.DateSent)
                   .FirstOrDefault());
