        public static ICollection<string[]> SplitAt(this string input, char target, int length, StringSplitOptions opts, bool trim = false)
        {
            var items = input.Split(new[] { target }, opts);
            if (trim) items = items.Select(x => x.Trim()).ToArray();
            return InternalSplitAt(items, length);
        }
        private static ICollection<string[]> InternalSplitAt(string[] items, int length)
        {
            var collectionToReturn = new List<string[]>();
            
            for (int i = 0; i < items.Length; i += length)
            {
                collectionToReturn.Add(items.Skip(i).Take(length).ToArray());
            }
            return collectionToReturn;
        }
