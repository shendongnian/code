    public static class Range {
        /// <summary>
        /// Create an <seealso cref="IRange&lt;T&gt;"/> using the provided minimum and maximum value
        /// </summary>
        public static IRange<T> Of<T>(T min, T max) where T : IComparable {
            return new Range<T>(min, max);
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool Contains<T>(this IRange<T> range, T value) where T : IComparable {
            return range.Minimum.CompareTo(value) <= 0 && value.CompareTo(range.Maximum) <= 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool IsOverlapped<T>(this IRange<T> range, IRange<T> other, bool inclusive = false) where T : IComparable {
            return inclusive
                ? range.Minimum.CompareTo(other.Maximum) <= 0 && other.Minimum.CompareTo(range.Maximum) <= 0
                : range.Minimum.CompareTo(other.Maximum) < 0 && other.Minimum.CompareTo(range.Maximum) < 0;
        }
        /// <summary>
        /// 
        /// </summary>
        public static IRange<T> GetIntersection<T>(this IRange<T> range, IRange<T> other, bool inclusive = false) where T : IComparable {
            var start = new[] { range.Minimum, other.Minimum }.Max();
            var end = new[] { range.Maximum, other.Maximum }.Min();
            var valid = inclusive ? start.CompareTo(end) < 0 : start.CompareTo(end) <= 0;
            return valid ? new Range<T>(start, end) : null;
        }
    }
