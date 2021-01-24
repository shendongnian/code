    uint GetRandomUInt()
    {
    	while (true)
    	{
    		int currentByteCachePosition = Interlocked.Add(ref _byteCachePosition, sizeof(uint));
    		if (currentByteCachePosition <= BYTE_CACHE_SIZE && currentByteCachePosition > 0)
    			return BitConverter.ToUInt32(_byteCache, currentByteCachePosition - sizeof(uint));
    
    		lock (_byteCache)
    		{
    			currentByteCachePosition = _byteCachePosition; // atomic read
    			if (currentByteCachePosition > (BYTE_CACHE_SIZE - sizeof(uint)) || currentByteCachePosition <= 0)
    			{
    				_fillBufferWithRandomBytes(_byteCache);
    				_byteCachePosition = sizeof(uint); // atomic write
    				return BitConverter.ToUInt32(_byteCache, 0);
    			}
    		}
    	}
    }
    public override int Next()
    {
    	// Mask away the sign bit so that we always return nonnegative integers
    	return (int)GetRandomUInt() & 0x7FFFFFFF;
    }
 
