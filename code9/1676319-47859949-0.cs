    public int EventID {
        get {
            // Apparently the top 2 bits of this number are not
            // always 0. Strip them so the number looks nice to the user.
            // The problem is, if the user were to want to call FormatMessage(),
            // they'd need these two bits.
            return IntFrom(dataBuf, bufOffset + FieldOffsets.EVENTID) & 0x3FFFFFFF;
        }
    }
