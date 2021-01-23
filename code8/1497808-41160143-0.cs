        private static IEnumerable<T> ZipThrough<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            using (var e1 = first.GetEnumerator())
            {
                using (var e2 = second.GetEnumerator())
                {
                    while (true)
                        if (e1.MoveNext())
                        {
                            yield return e1.Current;
                            if (e2.MoveNext()) yield return e2.Current;
                        }
                        else if (e2.MoveNext())
                        {
                            yield return e2.Current;
                        }
                        else
                        {
                            break;
                        }
                }
            }
        }
