        private static string CombineInternal(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
                return second;
            if (string.IsNullOrEmpty(second))
                return first;
            if (IsPathRooted(second.AsSpan()))
                return second;
            return JoinInternal(first.AsSpan(), second.AsSpan());
        }
