    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
        public static class ExtensionMethods
        {
            public static T FindFirstGap<T>(this IEnumerable<T> @this, Func<T, T> getNext, IEqualityComparer<T> comparer) where T : struct
            {
                using (var enumerator = @this.GetEnumerator())
                {
                    T nextItem = default(T);
                    while (enumerator.MoveNext())
                    {
                        var currentItem = enumerator.Current;
                        if (!comparer.Equals(currentItem, nextItem))
                            return nextItem;
                        nextItem = getNext(currentItem);
                    }
                    return nextItem;
                }
            }
            public static T FindFirstGap<T>(this IEnumerable<T> @this, Func<T, T> getNext) where T : struct
            {
                return FindFirstGap(@this, getNext, EqualityComparer<T>.Default);
            }
            public static int FindFirstGap(this IEnumerable<int> @this)
            {
                return FindFirstGap(@this, i => i + 1, EqualityComparer<int>.Default);
            }
            public static long FindFirstGap(this IEnumerable<long> @this)
            {
                return FindFirstGap(@this, i => i + 1, EqualityComparer<long>.Default);
            }
            public static short FindFirstGap(this IEnumerable<short> @this)
            {
                return FindFirstGap(@this, i => (short)(i + 1), EqualityComparer<short>.Default);
            }
            public static byte FindFirstGap(this IEnumerable<byte> @this)
            {
                return FindFirstGap(@this, i => (byte)(i + 1), EqualityComparer<byte>.Default);
            }
        }
    }
