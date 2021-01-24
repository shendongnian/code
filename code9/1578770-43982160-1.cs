    private static byte[] _bits;
    public static byte[] Bits
    {   get
        {
            if(_bits == null)
                SetBits();
            return _bits;
        }
        private set
        {
            _bits = value;
        }
    }
