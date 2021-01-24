     public static TCollection ForEachAndReturn<TCollection,TItem>(this TCollection Container, Action<TItem> action)
            where TCollection : IEnumerable<TItem>
        {
            foreach (var item in Container)
            {
                action(item);
            }
            return Container;
        }
