    public static IEnumerable<Interval<T>> GetOverlappingIntervals<T>(this IEnumerable<Interval<T>> intervals)
        where T : IComparable<T>
    {
        var stack = new Stack<Interval<T>>();
        foreach (var interval in intervals.OrderBy(i => i.LowerBound))
        {
            if (stack.Count == 0)
            {
                stack.Push(interval);
            }
            else
            {
                var previous = stack.Peek();
                if (Interval<T>.AreOverlapping(interval, previous))
                {
                    stack.Pop();
                    stack.Push(Interval<T>.Union(interval, previous));
                }
                else
                {
                    stack.Push(interval);
                }
            }
        }
        return stack;
    }
