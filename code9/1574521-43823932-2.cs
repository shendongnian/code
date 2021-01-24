            var dates = new List<List<DateTime>>();
            List<DateTime> weekDays = new List<DateTime>();
            for(var dt = start; dt<=end;dt=dt.AddDays(1))
            {
                
                if(dt.DayOfWeek != DayOfWeek.Sunday || DateTime.Compare(dt,start)==0)
                {
                    weekDays.Add(dt);
                }
                else
                {
                    weekDays.Add(dt);
                    dates.Add(weekDays);
                    weekDays = new List<DateTime>();
                }
            }
            if(weekDays.Count>0)
            {
                dates.Add(weekDays);
            }
