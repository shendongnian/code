    public static byte[] YV12toNV21(final byte[] input,
                                    final byte[] output, final int width, final int height) {
    
        final int size = width * height;
        final int quarter = size / 4;
        final int vPosition = size; // This is where V starts
        final int uPosition = size + quarter; // This is where U starts
    
        System.arraycopy(input, 0, output, 0, size); // Y is same
    
        for (int i = 0; i < quarter; i++) {
            output[size + i*2 ] = input[vPosition + i]; // For NV21, V first
            output[size + i*2 + 1] = input[uPosition + i]; // For Nv21, U second
        }
        return output;
    }
