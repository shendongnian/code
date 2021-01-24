    public bool DoFingerPrintsMatch(byte[] a1, byte[] b1)
    {
        var i = 0;
        if (a1.Length != b1.Length)
        {
            return i == a1.Length;
        }
    
        while ((i < a1.Length) && (a1[i] == b1[i]))
        {
            i++;
        }
    
        return i == a1.Length;
    }
