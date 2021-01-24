    public class EntityClass
    {
        public int NotificationType { get; set; }
        public int ConversationId { get; set; }
        public DateTime Created { get; set; }
        public static EntityClass GetLastNotification(int convId)
        {
            var list = new List<EntityClass>(); // Fill the values
            list = list
                .GroupBy(i => i.ConversationId) // Group by ConversationId.
                .ToDictionary(i => i.Key, n => n.ToList()) // Create dictionary.
                .Where(i => i.Key == convId) // Filter by ConversationId.
                .SelectMany(i => i.Value) // Project multiple lists to ONLY one list.
                .ToList(); // Create list.
            // Now, you can filter it:
            // 0 - NotificationType.AppMessage
            // I didn't get what exactly you want to filter there, but this should give you an idea.
            var lastNotification = list.OrderByDescending(i => i.Created).FirstOrDefault(i => i.NotificationType == 0);
            return lastNotification;
        }
    }
