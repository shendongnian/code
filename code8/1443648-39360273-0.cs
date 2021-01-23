     string output = string.Empty;
     DateTime max = new DateTime();
     foreach(string str in list)
     {
                DateTime tempDate = new DateTime();                
                DateTime.TryParseExact(str.Substring(str.IndexOf("_") + 1, 8), "yyyyMMdd", CultureInfo.GetCultureInfo("en-Us"), DateTimeStyles.None , out tempDate);
                if(tempDate > max)
                {
                    max = tempDate;
                    output = str;
                }
     }
