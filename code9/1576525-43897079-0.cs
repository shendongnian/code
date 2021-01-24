    using System;
    using System.Collections.Generic;
    public static class EnumerableUtilities
    {
        public static IEnumerable<int> RangePython(int start, int stop, int step = 1)
        {
            if (step == 0)
                throw new ArgumentException("Parameter step cannot equal zero.");
            if (start < stop && step > 0)
            {
                for (var i = start; i < stop; i += step)
                {
                    yield return i;
                }
            }
            else if (start > stop && step < 0)
            {
                for (var i = start; i > stop; i += step)
                {
                    yield return i;
                }
            }
        }
        public static IEnumerable<int> RangePython(int stop)
        {
            return RangePython(0, stop);
        }
    }
