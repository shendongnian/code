    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct tCashBox
    {
        public tCashBox(int param)
        {
            acCurrency = new char[4];
            lDenomination = 0;
            iRemainCount = 0;
            iCount = 0;
            iOutCount = 0;
            iRejectCount = 0;
            iPurgeCount = 0;
            byHopper = 0;
            cStatus = '\0';
            cLastStatus = '\0';
            acBoxID = new char[6];
            byBoxType = 0;
            acReserved1 = new char[10];
            acReserved2 = new char[10];
            iReserverd1 = 0;
            iReserverd2 = 0;
        }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] acCurrency;
        public int lDenomination;
        public int iRemainCount;
        public int iCount;
        public int iOutCount;
        public int iRejectCount;
        public int iPurgeCount;
        public byte byHopper;
        public char cStatus;
        public char cLastStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] acBoxID;
        public byte byBoxType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] acReserved1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] acReserved2;
        public int iReserverd1;
        public int iReserverd2;
    }
