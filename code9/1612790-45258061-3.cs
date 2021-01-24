    var scheduledExecutionTimes = new List<DateTime>();
    for (int i = 0; i < radGridView4.Rows.Count; i++)
    {
        DateTime executionTime = Convert.ToDateTime(radGridView4.Rows[i].Cells[10].Value.ToString());
                
        if (!scheduledExecutionTimes.Contains(executionTime))
        {            
            string content = radGridView4.Rows[i].Cells[2].Value.ToString();
            ScheduleAction(action, content, executionTime);
            // Add this time to our list
            scheduledExecutionTimes.Add(executionTime);
        }
    }
