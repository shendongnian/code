    var segments = filename.Split(new char[] { '_', '-' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    return segments.Cartesian(segments, (x, y) => x == y ? null : x + y)
        .Where(z => z != null)
        .Union(segments)
        .ToList();
