    public static TimeSpan ConvertStringToTimeStamp(string s)
            {
                // add checks for input like >0, not null or empty
    
                var split = s.Split(':');
                TimeSpan ts;
    
                switch (split.Length)
                {
                    case 3:
                        ts = new TimeSpan(int.Parse(split[0]),    // hours
                                           int.Parse(split[1]),   // minutes
                                           int.Parse(split[2]));  // seconds                            // seconds);
                        break;
                    case 2:
                        ts = new TimeSpan(int.Parse(split[0]),    // hours
                                           int.Parse(split[1]),    // minutes
                                           0);                     // 0 seconds
                        break;
                    case 1:
                        ts = new TimeSpan(int.Parse(split[0]),    // hours
                                           0,                     // 0 minutes
                                           0);                    // 0 seconds
                        break;
                    default:
                        throw new Exception("Invalid Input");
    
                }
    
                return ts;
            }
    
