    public static class DateTimeExtensions
    {
        public enum LeapYearIssue
        {
            ThrowException,
            RoundToMarch,
            RoundToFebruary,
            CustomDateTime
        }
        public static DateTime ChangeYear(this DateTime dt, int newYear, LeapYearIssue leapYearIssueAction = LeapYearIssue.ThrowException, DateTime leapYearIssueCustomDateTime = default(DateTime))
        {
            try
            {
                DateTime dtNew = new DateTime(newYear, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                return dtNew;
            }
            catch (ArgumentOutOfRangeException aoorEx)
            {
                if (dt.Month == 2 && dt.Day == 29)
                {
                    switch (leapYearIssueAction)
                    {
                        case LeapYearIssue.ThrowException:
                            throw new Exception("Passed dateTime was in leapyear but target year not", aoorEx);
                        case LeapYearIssue.CustomDateTime:
                            return leapYearIssueCustomDateTime;
                        case LeapYearIssue.RoundToFebruary:
                            return new DateTime(newYear, 2, 28, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                        case LeapYearIssue.RoundToMarch:
                            return new DateTime(newYear, 3, 1, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
                        default:
                            throw new Exception("Passed dateTime was in leapyear but target year not. leapYearIssueAction was unknown: " + leapYearIssueAction.ToString(), aoorEx);
                    }
                }
                else
                {
                    throw;
                }
            }
        }
    }
