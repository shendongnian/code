    [StructLayout(LayoutKind.Explicit)]
    struct MMTPMsg
    {
        [FieldOffset(0)]
        public long length;
        [FieldOffset(8)]
        public short Type;
        [FieldOffset(10)]
        public MMTPConxReq ConxReq;
        [FieldOffset(10)]
        public MMTPConxAck ConxAck;
        [FieldOffset(10)]
        public  MMTPConxNack ConxNack;
        [FieldOffset(10)]
        public MMTPErrInd ErrInd;
        [FieldOffset(10)]
        public MMTPDcnxReq DcnxReq;
        [FieldOffset(10)]
        public  MMTPDcnxAck DcnxAck;
        [FieldOffset(10)]
        public MMTPDataMsg DataMsg;
        [FieldOffset(10)]
        public MMTPSyncAck SyncAck;
        [FieldOffset(10)]
        public  MMTPStartReq StartReq;
        [FieldOffset(10)]
        public MMTPStartAck StartAck;
        [FieldOffset(10)]
        public  MMTPStartNack StartNack;
        [FieldOffset(10)]
        public  MMTPSrvcMsg SrvcMsg;
        [FieldOffset(10)]
        public MMTPDsptchMsg DsptchMsg;
        [FieldOffset(10)]
        public  MMTPRcnxReq RcnxReq;
        [FieldOffset(FIELD_SIZE_OPTIONS+1+8+2)]
        public  Ticks TimeStamp;
    }
