    public static Collection<T> ToCollection<T>
            (this IEnumerable<T> source)
            {
                if (source == null)
                {
                    throw new ArgumentNullException("source");
                }
                return new Collection<T>(source);
            }
