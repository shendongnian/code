            public async Task<byte[]> ReadAsync()
            {
                if (_IsReading)
                {
                    throw new Exception("Reentry");
                }
    
                lock (_Chunks)
                {
                    if (_Chunks.Count > 0)
                    {
                        var retVal = _Chunks[0];
                        Tracer?.Trace(false, retVal);
                        _Chunks.RemoveAt(0);
                        return retVal;
                    }
                }
    
                _IsReading = true;
                _TaskCompletionSource = new TaskCompletionSource<byte[]>();
                return await _TaskCompletionSource.Task;
    }
