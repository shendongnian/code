    int j=0;
    for (i = 0; i < objAttendanceLog.LogRecords.Count; i++)
    { 
        if (condition)
        {   
            for (j = i + 1; j < objAttendanceLog.LogRecords.Count - 1; j++)
            {
                if (condition)
                {
                 
                    while (j < objAttendanceLog.LogRecords.Count - 1)
                    {
                        if (condition)
                        {
                            j--;
                            break;
                        }
                        j++;
                    }
                    if (j == objAttendanceLog.LogRecords.Count)
                    {
                        j--;
                    }
                    num3 = data, 
                    i = j;
                    goto IL_AD8;
                }
            }
            
        }
        else{
             while (j < objAttendanceLog.LogRecords.Count - 1)
                    {
                        if (condition)
                        {
                            j--;
                            break;
                        }
                        j++;
                    }
                    if (j == objAttendanceLog.LogRecords.Count)
                    {
                        j--;
                    }
                    num3 = data, 
                    i = j;
                    goto IL_AD8;
        }
        IL_AD8:;
    }
