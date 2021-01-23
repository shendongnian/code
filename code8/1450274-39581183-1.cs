    void ProcessNewSamples(IEnumerable<int> newSamples)
    {
    	var frames = new List<Frame>();
    
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
    	            frames.Add(frame);
    	            _octet.Reset();
    	        }
    	    }
        }
    
        foreach (var frame in frames)
        {
        	this.SendElsewhere(frame)
        }
    }
