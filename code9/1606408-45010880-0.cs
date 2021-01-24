      foreach (ListItem listItem in items)
                    {
                        DateTime date = System.TimeZone.CurrentTimeZone.ToLocalTime((DateTime)listItem["u12q"]);
                        holidayDates.Add(date.Date);
                    }
