    var scheduledExecutionTimes = new List<DateTime>();
    for (int i = 0; i < radGridView4.Rows.Count; i++)
    {
        var executionTime = Convert.ToDateTime(radGridView4.Rows[i].Cells[10].Value.ToString());
        // Only schedule this item (and add it to the list) if it hasn't been scheduled before
        if (!scheduledExecutionTimes.Contains(executionTime))
        {
            scheduledExecutionTimes.Add(executionTime);
            ScheduleAction(action, executionTime);
        }
    }
