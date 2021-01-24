        protected override void Dispose(bool disposing) {
            try {
                if (disposing) {
                    if (!_finalBlockTransformed) {
                        FlushFinalBlock();
                    }
                    _stream.Close();
                }                
            }
            finally {
                try {
                    // Ensure we don't try to transform the final block again if we get disposed twice
                    // since it's null after this
                    _finalBlockTransformed = true;
                     // we need to clear all the internal buffers
                     if (_InputBuffer != null)
                         Array.Clear(_InputBuffer, 0, _InputBuffer.Length);
                     if (_OutputBuffer != null)
                         Array.Clear(_OutputBuffer, 0, _OutputBuffer.Length);
 
                     _InputBuffer = null;
                     _OutputBuffer = null;
                     _canRead = false;
                     _canWrite = false;
                }
                finally {
                     base.Dispose(disposing);
                }
            }
        }
