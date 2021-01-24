            protected override void Dispose(bool disposing)
            {
                Contract.Assert(_byteRangeContent != null);
                if (disposing)
                {
                    if (!_disposed)
                    {
                        _byteRangeContent.Dispose();
                        _content.Dispose();
                        _disposed = true;
                    }
                }
                base.Dispose(disposing);
            }
