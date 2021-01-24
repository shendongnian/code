      public struct SConfigList
    {
        public int Count { get; set; }
        public IntPtr ListPtr { get; set; }
        public List<SConfig> GetList()
        {
            if (ListPtr == IntPtr.Zero)
                return new List<SConfig>();
            return ListPtr.AsList<SConfig>(Count);
        }
    }
