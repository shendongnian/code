    foreach(var row in DataSet.ChildApplications.Rows)
    {
        if(!row.IsParentApplicationRoleIdNull())
        {
            Trace.WriteLine($"ParentApplicationRoleId: {row.ParentApplicationRoleId}");
        }
        else
        {
            Trace.WriteLine("ParentApplicationRoleId: is DBNull, and can't be shown");
      }
    }
