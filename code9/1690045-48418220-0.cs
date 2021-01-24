    private FileStreamAsyncResult BeginWriteAsync(byte[] array, int offset, int numBytes, AsyncCallback userCallback, Object stateObject)
            {
                Contract.Assert(_isAsync);
    
                if (!CanWrite) __Error.WriteNotSupported();
    
                Contract.Assert((_readPos == 0 && _readLen == 0 && _writePos >= 0) || (_writePos == 0 && _readPos <= _readLen), "We're either reading or writing, but not both.");
    
                if (_isPipe)
                {
                    // Pipes are ----ed up, at least when you have 2 different pipes
                    // that you want to use simultaneously.  When redirecting stdout
                    // & stderr with the Process class, it's easy to deadlock your
                    // parent & child processes when doing writes 4K at a time.  The
                    // OS appears to use a 4K buffer internally.  If you write to a
                    // pipe that is full, you will block until someone read from 
                    // that pipe.  If you try reading from an empty pipe and 
                    // FileStream's BeginRead blocks waiting for data to fill it's 
                    // internal buffer, you will be blocked.  In a case where a child
                    // process writes to stdout & stderr while a parent process tries
                    // reading from both, you can easily get into a deadlock here.
                    // To avoid this deadlock, don't buffer when doing async IO on
                    // pipes.   
                    Contract.Assert(_readPos == 0 && _readLen == 0, "FileStream must not have buffered data here!  Pipes should be unidirectional.");
    
                    if (_writePos > 0)
                        FlushWrite(false);
    
                    return BeginWriteCore(array, offset, numBytes, userCallback, stateObject);
                }
    
                // Handle buffering.
                if (_writePos == 0)
                {
                    if (_readPos < _readLen) FlushRead();
                    _readPos = 0;
                    _readLen = 0;
                }
    
                int n = _bufferSize - _writePos;
                if (numBytes <= n)
                {
                    if (_writePos == 0) _buffer = new byte[_bufferSize];
                    Buffer.InternalBlockCopy(array, offset, _buffer, _writePos, numBytes);
                    _writePos += numBytes;
    
                    // Return a synchronous FileStreamAsyncResult
                    return FileStreamAsyncResult.CreateBufferedReadResult(numBytes, userCallback, stateObject, true);
                }
    
                if (_writePos > 0)
                    FlushWrite(false);
    
                return BeginWriteCore(array, offset, numBytes, userCallback, stateObject);
            }
    #endif // FEATURE_ASYNC_IO
