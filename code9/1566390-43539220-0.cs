    lock(dt)
    {
    if (dt.Rows.Count > 0)
        {
            //Checks if table belongs to ds, if yes merge with the existing table, adds otherwise
            if (ds.Tables.Contains(dt.TableName))
            {
                ds.Tables[dt.TableName].Merge(dt);
            }
            else
            {
                ds.Tables.Add(dt);
            }
        }
    }
