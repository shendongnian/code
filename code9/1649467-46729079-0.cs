    query = query
        .Where(c => c.NotificationType == NotificationType.AppMessage)
        .GroupBy(c => c.ConversationId)
        .Select(d => d.OrderByDescending(p => p.DateCreated).FirstOrDefault())
        .Concat(query.Where(c => c.NotificationType != NotificationType.AppMessage);
