    public static class StackExtensions
    {
        public static void Replace<T>(this Stack<T> stack, T valueToReplace, T valueToReplaceWith, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
    
            var temp = new Stack<T>();
            while (stack.Count > 0)
            {
                var value = stack.Pop();
                if (comparer.Equals(value, valueToReplace))
                {
                    stack.Push(valueToReplaceWith);
                    break;
                }
                temp.Push(value);
            }
            
            while (temp.Count > 0)
                stack.Push(temp.Pop());
        }
    }
