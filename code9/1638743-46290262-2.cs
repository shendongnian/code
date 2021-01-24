    for (int i = 0; i < dt.Rows.Count; i++)
    {
        if (!Convert.IsDBNull(dt.Rows[i]["Time_Completed"]))
        {
            Obj.TimeCompleted = Convert.ToDateTime(dt.Rows[i]["Time_Completed"]);
        }
    }
