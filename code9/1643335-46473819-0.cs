    using (var context = new JITBModel())
    {
     
      var duplicates= context.BackupEvents
        .GroupBy(x => x.Full)
        .Where(grp => grp.Count() > 1)
        .Select(grp=>grp.FirstOrDefault());
      context.BackupEvents.RemoveRange(duplicates);
      context.SaveChanges();
    }
