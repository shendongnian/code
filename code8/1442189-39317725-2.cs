    public static int[] Str2Binl(string str)
    {
        var nblk = ((str.Length + 8) >> 6) + 1; // number of 16-word blocks
        var blks = new int[nblk*16];
    
        int i;
        for (i = 0; i < str.Length; i++)
        {
            blks[i >> 2] |= (str[i] & 0xFF) << (i%4*8);
        }
    
        blks[i >> 2] |= 0x80 << (i%4*8);
        blks[nblk*16 - 2] = str.Length*8;
        return blks;
    }
