       public DateTime CreateDayOfWeek(int DayOfWeek,int hour,int min)
            {
                DateTime dt = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,hour,min,0);
    
                
                // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
                int daysUntilTuesday = (DayOfWeek - (int)dt.DayOfWeek + 7) % 7;
                //  DateTime nextTuesday = today.AddDays(daysUntilTuesday);
    
    
                dt = dt.AddDays(daysUntilTuesday);
    
                return dt;
            }
