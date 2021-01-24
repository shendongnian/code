    foreach (var item in (IEnumerable)obj) {
        ICloneable cloneable = item as ICloneable;
        if (cloneable != null) {
            newC.Add(cloneable.Clone());
        }
        else {
            newC.Add(item);
        }
    }
