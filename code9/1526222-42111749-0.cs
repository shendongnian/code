            using (var actiContext = new ActigraphyContext())
            {
                var todayLastStatus =
                    from s in actiContext.DeviceStatus.Include(s1 => s1.Device.Panel)
                    where DbFunctions.TruncateTime(s.TimeStamp) == DbFunctions.TruncateTime( DateTimeOffset.Now)
                          && s.Device.Panel.Mac == mac
                          && (s.Device.Ty == 4 || s.Device.Ty == 9)
                    orderby s.TimeStamp descending 
                    select s;
                var requestResult = todayLastStatus.Take(1).FirstOrDefault();
                return requestResult;
            }
