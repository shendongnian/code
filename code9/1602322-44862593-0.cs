       public static class SystemDateTimeExtensions
        {
            /// <summary>
            /// Defines a period of time by setting two date times
            /// </summary>
            public class Period
            {
                public DateTime Start { get; set; }
                public DateTime End { get; set; }
            }
    
            /// <summary>
            /// Checks that a period of time is completely contained within another period of time.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="encapsulator"></param>
            /// <returns></returns>
            public static bool IsEnclosedByPeriod(this Period value, Period encapsulator)
            {
                //if the start of the smaller value is before or after the encapsulator, then we're not completely inside it.
                if (value.Start < encapsulator.Start || value.Start > encapsulator.End)
                    return false;
                //if the end of the smaller value is before or after the encapsulator, then we're not completely inside it.
                if (value.End < encapsulator.Start || value.End > encapsulator.End)
                    return false;
    
                //then we're fully inside!
                return true;
            }
        }
