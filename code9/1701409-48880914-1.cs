                DayOfWeek FromDateEnum;
                
               if (key == "FromDate")
                {
                  FromDate = applicationSettings[key];
                  Enum.TryParse<DayOfWeek>(FromDate, out FromDateEnum);
                }
