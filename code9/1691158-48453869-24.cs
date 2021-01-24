    public static IEnumerable<Item> ItemDescendentsFlat(IEnumerable<Item> src, int parent_id) {
        void PushRange<T>(Stack<T> s, IEnumerable<T> Ts) {
            foreach (var aT in Ts)
                s.Push(aT);
        }
    
        var itemStack = new Stack<Item>(src.Where(i => i.Id_Parent == parent_id));
    
        while (itemStack.Count > 0) {
            var item = itemStack.Pop();
            PushRange(itemStack, src.Where(i => i.Id_Parent == item.Id));
            yield return item;
        }
    }
