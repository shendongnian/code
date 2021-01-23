    // add the new ones...
    foreach (var newItem in newList.Where(n => !oldList.Any(o => o.Id == n.Id))) {
        oldList.Add(newItem);
    }
    // remove the redundant ones...
    var oldIds = oldList.Select(i => i.Id);
    foreach (var oldId in oldIds) {
        if (!newList.Any(i => i.Id == oldId)) {
            oldList.Remove(oldList.First(i => i.Id == oldId));
        }
    }
