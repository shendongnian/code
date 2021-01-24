        /// <summary>
        /// Sends a "window-change" request.
        /// </summary>
        /// <param name="columns">The terminal width in columns.</param>
        /// <param name="rows">The terminal width in rows.</param>
        /// <param name="width">The terminal height in pixels.</param>
        /// <param name="height">The terminal height in pixels.</param>
        public void SendWindowChangeRequest(uint columns, uint rows, uint width, uint height)
        {
            if (_channel == null)
            {
                throw new ObjectDisposedException("ShellStream");
            }
            _channel.SendWindowChangeRequest(columns, rows, width, height);
        }
