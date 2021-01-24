        public static IEnumerable<KeyValuePair<A, A>> KeyValueSelecting(ICollection<A> source) {
            if (null == source) { throw new ArgumentNullException(nameof(source)); }
            for (var i = 0; i < source.Count - 1; i++) {
                var firstElement = source.ElementAtOrDefault(i);
                if (firstElement?.Something != "A") { yield break; }
                var seceondElement = source.ElementAtOrDefault(i + 1);
                if (seceondElement?.Something != "B") { yield break; }
                yield return new KeyValuePair<A, A>(firstElement, seceondElement);
            }
        }
