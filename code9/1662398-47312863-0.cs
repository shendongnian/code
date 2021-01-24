            public struct DATA_BUFFER
        {
            public IntPtr  buffer;
            [MarshalAs(UnmanagedType.U4)]
            public int length;
            [MarshalAs(UnmanagedType.U4)]
            public int transferCount;
        }
