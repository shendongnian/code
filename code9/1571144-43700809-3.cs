    const int N = 3 * 255 * 300;
    // Create the keys
    var keys = new Key[N];
    int i = 0;
    for (byte c = 0; c <= 2; c++) {
        for (int p = 1; p <= 255; p++) { // int because byte overflows after last loop.
            for (uint l = 1; l <= 300; l++) {
                keys[i++] = new Key { code = c, param = (byte)p, len = l };
            }
        }
    }
    // Select 3 keys
    for (i = 0; i < N; i++) {
        Key k1 = keys[i];
        for (int j = 0; j < N; j++) {
            Key k2 = keys[j];
            for (int k = 0; k < N; k++) {
                Key k3 = keys[k];
                // Do something with k1, k2, k3
            }
        }
    }
