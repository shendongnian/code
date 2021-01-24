    // 8 + (numDi*4) bytes
    [Serializable]
    public struct MyPacket
    {
        public uint ProtocolIdentifier;
        public uint NumDi;
        public DiObject[] Di;
    }
