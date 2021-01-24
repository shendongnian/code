    var isAscending = GetIsAscending(sort);
    var pi = typeof(T).GetProperty(parameter);
    if (pi != null)
        user = isAscending
            ? user.OrderBy(a => pi.GetValue(a, null))
            : user.OrderByDescending(a => pi.GetValue(a, null));
