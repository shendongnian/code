    var mat = new byte[3, 3];
    var list = new List<byte[,]>();
    for (int m = 0; m < 9; ++m) {
        byte i, j = 0;
        // Search for an empty cell (zero)
        bool flag = false;
        for (i = 0; i < 3; ++i) {
            for (j = 0; j < 3; ++j)
                if (mat[i, j] == 0) {
                    flag = true;
                    $"flag == {flag}".Dump();
                    break;
                }
            if (flag) break;
        }
        // Adding a changed array to the list
        mat[i, j] = 1;
        list.Add((byte[,])mat.Clone());
    }
    // List all items in the list
    foreach (byte[,] a in list) {
        a.Dump();
    }
