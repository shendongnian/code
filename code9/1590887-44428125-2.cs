    String newFileName = Path.Combine(@"E:\BR_AttendanceDownloadLogs",
                         DateTime.Today.ToString("yyyyMMdd") + ".csv");
    
    if(!File.Exists(newFileName))
    {
        string clientHeader = $"\"EmployeeCode\",\"Date\",\"Time\",\"Type\",\"Remarks\"{Environment.NewLine}";
        File.WriteAllText(newFileName, clientHeader);
    }
