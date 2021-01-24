    // ... declarative section, downgrade to Dictionary class if thread-safe concurrency is not needed
    ConcurrentDictionary<string, int> files_for_cleanup = new ConcurrentDictionary<string, int>();
    
    // ... bottom of your processing loop
    if (!files_for_cleanup.ContainsKey(current_temp_file))
    {
        files_for_cleanup.TryAdd(current_temp_file, 0);
    }
    
    // ... switching to cleanup thread, if threaded, otherwise continue with the bottom of your processing loop
    KeyValuePair<string, int> item = null;
    try
    {
      while(!files_for_cleanup.IsEmpty)
      {
        item = files_for_cleanup.First();
        if(File.Exists(item.Key)
        {
          File.Delete(item.Key);
        }
        files_for_cleanup.TryRemove(item.Key, item.Value);
      }
    }
    catch(Exception)
    {
      if (item != null)
      {
        if (item.Value > 40 /* retry threshold */)
        {
          files_for_cleanup.TryRemove(item.Key, item.Value);
          // ... perform other unrecoverable actions, e.g. logging, delete on reboot, ...
        }
        
        else
        {
          files_for_cleanup.TryUpdate(item.Key, item.Value, item.Value + 1);
        }
      }
    }
    
    //  ... if in thread, spinwait, sleep, etc.  otherwise return to top of loop
