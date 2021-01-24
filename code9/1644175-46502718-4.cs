        static volatile bool processStop = false;
        static volatile bool processStopped = false;
        
        //Called once 
        private async void ProcessData()
        {
            await Task.Run(() =>
            {
        		while (!processStop)
        		{
                    ...
                }
                processStopped = true;
        	});
        }
    This would require changing the form of the method passed to work with the loop in it.
