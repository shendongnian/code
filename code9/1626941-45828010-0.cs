       /// <summary>
        /// Generates the full path for the Filesystem mappings for this GPIO pin
        /// </summary>
        public string FullPath
        {
            get
            {
                return this.Path + "/" + this.FullPath;
            }
        }
