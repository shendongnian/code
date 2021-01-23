    /// <summary>
    /// Utility class for runtime platform detection
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// True if 64-bit runtime is used
        /// </summary>
        public static bool Uses64BitRuntime
        {
            get
            {
                return (IntPtr.Size == 8);
            }
        }
        /// <summary>
        /// True if 32-bit runtime is used
        /// </summary>
        public static bool Uses32BitRuntime
        {
            get
            {
                return (IntPtr.Size == 4);
            }
        }
    }
