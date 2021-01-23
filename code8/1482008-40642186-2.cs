    [HandleProcessCorruptedStateExceptions] 
    [SecurityCritical]
    public ICollection<TherapyGroup> OffUnit()
    {
          try
          {
              return _context.TherapyGroups.OrderBy(g => g.Name).Where(x => x.GroupTypeOffUnitOnUnit == TherapyGroup.OffUnit).ToList();
          }
          catch (Exception e)
          {
              // set break point to see the stack trace.
              Debug.WriteLine(e.InnnerException);
              return null;
          }
           finally
           {
               return default_value;
           }
    }
