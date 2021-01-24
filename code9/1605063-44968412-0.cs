    public void CreateQueueIfNotExists(string queueName, List<string> users)
    {
        if (!MessageQueue.Exists(queueName))
        {
            MessageQueue.Create(queueName);
            var queue = new MessageQueue(queueName);
            //set permissions for those users
            foreach (var user in users)
            {
                queue.SetPermissions(user, MessageQueueAccessRights.ReceiveMessage | MessageQueueAccessRights.WriteMessage, AccessControlEntryType.Allow);
            }
        }
    }
