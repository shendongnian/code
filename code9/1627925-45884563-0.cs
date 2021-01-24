    // You can pass connectivity as constructor argument. Default is 8.
    foreach (var lip in new LineIterator(img, pt1, pt2)) {
        Point p = lip.Pos;
        // Use appropriate type for generic GetValue<of T>().
        byte v = lip.GetValue<byte>();
    }}
