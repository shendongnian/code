    static string moveToNewPath = "...";
    static string filePath = "...";
    static string logFormat = "\n{0:s}\t{1}";
    static string logFile = "";
    static string directoryPath = "...";
    static void LogMessage(string FilePath, string Message)
    {
        File.AppendAllText(Path.Combine(filePath, logFile),
             string.Format(logFormat, DateTime.Now, Message.Replace("\n", " ")));
    }
    static void Main(string[] args)
    {
        logFile = "log_" + DateTime.Today.ToString("MMMM") + ".txt";
        //Rotate log file on last day of month
        try 
        {
            var todaysDate = DateTime.Now.Date;
            var firstOfMonth = new DateTime(todaysDate.Year, todaysDate.Month, 1);
            var monthEnd = firstOfMonth.AddMonths(1).AddDays(-1);
            if (todaysDate == monthEnd)
            {
                File.Move(Path.Combe(filePath, logFile), Path.Combine(moveToNewPath, logFile));
            }
        }
        catch (Exception ex)
        {
             LogMessage(ex.Message);
        }
        while (true)
        {
            // !!!!!!!!!!!!!!
            //Log rotate code used to be here... but... you need something to be sure this only happens once per day.
            // I STRONGLY suspect this code should be setup to run as 
            //   a SCHEDULED TASK set to run once per day or maybe once per hour, rather than an always-on background program.
            // !!!!!!!!!!!!!!!!
            try
            {
                var moveTo = Path.Combine(directoryPath, "Processed_" + DateTime.Today.ToString("MMMM"));
                Directory.CreateDirectory(moveTo);
                var files = Directory.GetFiles(filePath).Where(f => f.EndsWith("myFile.csv"));
                foreach (var fileName in files)
                {
                    var fileValues = File.ReadAllLines(filePath + fileName.Substring(44)).Skip(1).Select(v => new myFile(v));
                    foreach (var i in fileValues)
                    {
                        try
                        {
                            var jsonValues = ValueFromFile(i);
                            var response = UploadData(url, username, password, jsonValues);
                            LogMessage(response); 
                        }
                        catch (Exception ex)
                        {
                            LogMessage(ex.Message); 
                        }
                    }
                    File.Move(fileName, Path.Combine(moveTo, "processedMyFile" + DateTime.Now.Date.ToString("MM-dd-yy") + ".csv"));
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }
    }
