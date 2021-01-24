            var TimeZoneList=TimeZoneInfo.GetSystemTimeZones();
            foreach(var i in TimeZoneList)
            {
                TimeSpan ts = i.GetUtcOffset(DateTime.Now);
                if (ts.ToString().Contains("-"))
                {
                    string s = "(UTC" + ts.ToString() + ")" + i.StandardName;
                   
                }
                else
                {
                    string s = "(UTC+" + ts.ToString() + ")" + i.StandardName;
                  
                }
            }
