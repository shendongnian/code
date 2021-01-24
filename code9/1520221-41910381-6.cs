        class Producer
        {
    
    	public event EventHandler<double> YSeriesEvent;
        private Thread thread;
    	
        public Producer()
    	{
    		thread = new Thread(new ThreadStart(this.Work));
    		thread.IsBackground = true;
    		thread.Name = "My Worker.";		
    	}
    	
    	public void Start()
    	{
    		thread.Start();
    	}
    	
    	private void Work()
    	{
    		int counter = 0;
    
    		while (true)
    		{
    			counter++;
    			WebClient code = new WebClient();
    			speed_str = code.DownloadString("http://192.168.19.41/speedfile.html");
    			speedval = Convert.ToDouble(speed_str);
    			YSeriesEvent?.Invoke(this, speedval);
    		}
    	}
       }
