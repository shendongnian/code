        class TimeParser
        {
            Regex tripleReg = new Regex(@"([\d]{1,2}):([\d]{1,2}):([\d]{1,2})");
            Regex doubleReg = new Regex(@"([\d]{1,2}):([\d]{1,2})");
            public enum Format
            {
                HoursMinutesSeconds,
                HoursMinutes,
                MinutesSeconds
            }
            public TimeSpan Parse(string data)
            {
                if (tripleReg.IsMatch(data))
                    return Parse(data, Format.HoursMinutesSeconds);
                else
                {
                    var match = doubleReg.Match(data);
                    var segment = match.Groups[1];
                    var value = int.Parse(segment.Value);
                    if (value < 60)
                        return Parse(data, Format.MinutesSeconds);
                    else
                        return Parse(data, Format.HoursMinutes);
                }
            }
            public TimeSpan Parse(string data, Format format)
            {
                TimeSpan result;
                Match match;
                var hours = 0;
                var minutes = 0;
                var seconds = 0;
                switch (format)
                {
                    case Format.HoursMinutesSeconds:
                        match = tripleReg.Match(data);
                        if (match.Success)
                        {
                            int.TryParse(match.Groups[1].Value, out hours);
                            int.TryParse(match.Groups[2].Value, out minutes);
                            int.TryParse(match.Groups[3].Value, out seconds);
                        }
                        break;
                    case Format.HoursMinutes:
                        match = doubleReg.Match(data);
                        if (match.Success)
                        {
                            int.TryParse(match.Groups[1].Value, out hours);
                            int.TryParse(match.Groups[2].Value, out minutes);
                        }
                        break;
                    case Format.MinutesSeconds:
                        match = doubleReg.Match(data);
                        if (match.Success)
                        {
                            int.TryParse(match.Groups[1].Value, out minutes);
                            int.TryParse(match.Groups[2].Value, out seconds);
                        }
                        break;
                    default:
                        break;
                }
                result = new TimeSpan(hours, minutes, seconds);
                return result;
            }
        }
