            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        /// <param name="disposing">Whether this method is called from Dispose.</param>
        protected void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_file != null)
                {
                    _file.Dispose();
                    _file = null;
                }
                _disposed = true;
            }
        }
