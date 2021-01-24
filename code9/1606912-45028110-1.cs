            static Regex myTimePattern = new Regex(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
                static TimeSpan DurationTimespan(string s)
                {
                    if (s == null) throw new ArgumentNullException("s");
                    Match m = myTimePattern.Match(s);
                    if (!m.Success)
                        throw new ArgumentOutOfRangeException("s");
                    DateTime DT = DateTime.Parse(s);
                    TimeSpan value = new TimeSpan(DT.Hour, DT.Minute, 0);
                    if (DT.Minute < 0 || DT.Minute > 59)
                        throw new ArgumentOutOfRangeException("s");
                    return value;
                }
