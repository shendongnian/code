    public void LogAdd(string processName, T item, List<T> items)
    {
        try
        {
            LogInfo entity = new LogInfo();
            entity.ProcessName = processName;
            if (item != null)
                entity.Data = JsonConvert.SerializeObject(item);
            else if(items.Count!=0)
                entity.Data = JsonConvert.SerializeObject(items);
            entity.CreateDate = System.DateTime.Now;
            Context.Set<LogInfo>().Add(entity);
            Context.SaveChanges();
        }
        catch (Exception exp)
        {
        }
    }
