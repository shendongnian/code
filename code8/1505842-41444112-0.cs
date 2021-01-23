    for (int i = 1; i <= lines.Length; i++)
    {
        if (lines[i].Contains("Code"))
        {
            string countryCode = lines[i].Substring(15);
            using (var client = new WebClient())
            {
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                Uri uri = new Uri("http://api.sat24.com/animated/" + countryCode + "/infraPolair/1/JerusalemStandardTime/1897199");
                client.DownloadFile(uri, @"c:\temp\" + countriesNames[countCountries] + ".gif");
            }
            countCountries++;
        }
        backgroundWorker1.ReportProgress(i * 100 / lines.Length);
    }
