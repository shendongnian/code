    public class TimeSegment
    {
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        public TimeSegment(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        public TimeSegment[] Subtract(TimeSegment other)
        {
            // 8-10 Subtract 10-11 = 8-10
            if (StartTime > other.EndTime || other.StartTime > EndTime)
            {
                // If there is no intersection, we return { this }
                // (no subtraction)
                return new[] { this };
            }
            if (StartTime >= other.StartTime)
            {
                // 8-10 Subtract 8-10 = (nothing)
                // 8-10 Subtract 7-11 = (nothing)
                if (EndTime <= other.EndTime)
                {
                    // Total subtraction, nothing remains!
                    return new TimeSegment[0];
                }
                else
                {
                    // 8-10 Subtract 7-9 = 9-10
                    return new[] { new TimeSegment(other.EndTime, EndTime) };
                }
            }
            // 8-12 Subtract 9-13 = 8-9
            if (EndTime <= other.EndTime)
            {
                return new[] { new TimeSegment(StartTime, other.EndTime) };
            }
            // 8-12 Subtract 9-11 = 8-9, 11-12
            // Complete case: two TimeSegments returned
            return new[] { new TimeSegment(StartTime, other.StartTime), new TimeSegment(other.EndTime, EndTime) };
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}", StartTime, EndTime);
        }
    }
