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
            if (StartTime > other.EndTime || other.StartTime > EndTime)
            {
                // If there is no intersection, we return { this }
                // (no subtraction)
                return new[] { this };
            }
            if (StartTime >= other.StartTime)
            {
                if (EndTime <= other.EndTime)
                {
                    // Total subtraction, nothing remains!
                    return new TimeSegment[0];
                }
                else
                {
                    return new[] { new TimeSegment(other.EndTime, EndTime) };
                }
            }
            if (EndTime <= other.EndTime)
            {
                return new[] { new TimeSegment(StartTime, other.EndTime) };
            }
            // Complete case: two TimeSegments returned
            return new[] { new TimeSegment(StartTime, other.StartTime), new TimeSegment(other.EndTime, EndTime) };
        }
        public override string ToString()
        {
            return string.Format("{0}-{1}", StartTime, EndTime);
        }
    }
