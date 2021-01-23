    void ProcessNewSamples(IEnumerable<int> newSamples)
    {
    	lock (this)
    	{
    	    foreach (int sample in newSamples)
    	    {
    	        if (!_octet.IsFull)
    	        {
    	            _octet.Add(sample);
    	        }
    
    	        if (_octet.IsFull)
    	        {
    	            var frame = _octet.ExtractFrame();
    	            this.SendElsewhere(frame);
    	            _octet.Reset();
    	        }
    	    }
        }
    }
    
