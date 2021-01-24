    public static class Extensions {
        public static TCollection CreateCopy<TCollection, TItem>(this TCollection c) where TCollection : ICollection<TItem>, new() {
            var copy = new TCollection();
            foreach (var item in c) {
                copy.Add(item);
            }
            return copy;
        }
    }
