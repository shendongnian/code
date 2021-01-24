	/// <summary>
	/// How many characters should get read at once max.
	/// </summary>
	private static readonly int BUFFER_SIZE = 4096;
	private StreamSocket socket;
	private DataReader dataReader;
    private DataWriter dataWriter;
    public string readNextString() {
	    string result = "";
	    readingCTS = new CancellationTokenSource();
    	try {
	    	uint readCount = 0;
		    // Read the first batch:
    		Task < uint > t = dataReader.LoadAsync(BUFFER_SIZE).AsTask();
	    	t.Wait(readingCTS.Token);
		    readCount = t.Result;
    		if (dataReader == null) {
	    		return result;
		    }
    		while (dataReader.UnconsumedBufferLength > 0) {
	    		result +=dataReader.ReadString(dataReader.UnconsumedBufferLength);
	    	}
		    // If there is still data left to read, continue until a timeout occurs or a close got requested:
    		while (!readingCTS.IsCancellationRequested && readCount >= BUFFER_SIZE) {
	    		t = dataReader.LoadAsync(BUFFER_SIZE).AsTask();
		    	t.Wait(100, readingCTS.Token);
			    readCount = t.Result;
    			while (dataReader.UnconsumedBufferLength > 0) {
	    			result += dataReader.ReadString(dataReader.UnconsumedBufferLength);
		    	}
    		}
	    }
    	catch(AggregateException) {}
	    catch(NullReferenceException) {}
    	return result;
    }
