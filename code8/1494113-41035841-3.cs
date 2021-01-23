    int[] values = new int[bigBitArray.Length / 32];
    bigBitArray.CopyTo(values, 0);
    // Reuse this on every iteration, to avoid creating more arrays than we need.
    // Somewhat ugly, but more efficient.
    int[] buffer = new int[1];
    var smallBitArrays = values.Select(v =>
    { 
        buffer[0] = v; 
        return new BitArray(buffer))
    }).ToList();
