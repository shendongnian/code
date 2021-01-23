    while (pendingLogs.Count > 0)
    {
         lock (pendingLogs)
         {
              entity = null;
              if (pendingLogs.Count > 0)
              {
                 entity = pendingLogs[0];
                 pendingLogs.RemoveAt(0);
              }
         }
         if (entity != null)
         {
              context.Entities.Add(entity);
         }
    }
    context.SaveChanges();
