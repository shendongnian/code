        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct BusPortInfo {
            public int portInfoSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string portText;
            public bool portLocked;
            public BusPortId portId;
        }
