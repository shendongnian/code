    public static class StackExt
    {
        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> range)
        {
            // Null checks elided for simplicity.
            foreach (var item in range)
                stack.Push(item);
        }
    }
