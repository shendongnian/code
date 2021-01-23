      public struct AccountInfo
      {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ExpirationDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string CustomerId;
      }
