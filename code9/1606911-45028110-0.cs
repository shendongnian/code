            static Regex myTimePattern = new Regex(@"((\d+)+(\:\d+))$");
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
