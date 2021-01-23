        static void Main(string[] args)
        {
            var list = new ArrayList {3, "test", null};
            var result = AsEnumerable(list).Any(x => x == null);
        }
        private static IEnumerable<object> ToEnumerable(ArrayList data)
        {
            var enumerator = data.GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
