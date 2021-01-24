        public static class Extensions
        {
            public static Dictionary<int, T> GetRandomElements<T>(this IList<T> list, int quantity)
            {
                var result = new Dictionary<int, T>();
                if (list == null)
                    return result;
                Random rnd = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < quantity; i++)
                {
                    int idx = rnd.Next(0, list.Count);
                    result.Add(idx, list[idx]);
                }
                return result;
            }
        }
