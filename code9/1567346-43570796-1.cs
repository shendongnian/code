        // using System.Runtime.CompilerServices;
        public long MyConfig1
        {
            get
            {
                return getConfig();
            }
        }
        private long getConfig([CallerMemberName] string propertyName = null)
        {
        }
