    /// <summary>
    /// Access the current <see cref="IPlatformProvider"/>.
    /// </summary>
    public static class PlatformProvider {
        private static IPlatformProvider current = new XamlPlatformProvider();
        /// <summary>
        /// Gets or sets the current <see cref="IPlatformProvider"/>.
        /// </summary>
        public static IPlatformProvider Current {
            get { return current; }
            set { current = value; }
        }
    }
