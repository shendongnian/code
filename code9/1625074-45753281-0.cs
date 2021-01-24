    public bool TryRemove(IEnumerable c) {
        foreach (object o in c)
            if (!TryRemove(o))
                return false;
        return true;
    }
    public bool TryRemove(object o) {
        for (int index = 0; index < list.Count; index++)
            if (ItemsEqual(list[index], o)) {
                list.RemoveAt(index);
                return true;
            }
        return false;
    }
