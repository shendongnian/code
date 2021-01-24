    protected override bool Test()
    {
        using (Websocket ws = new Websocket()) // properly dispose of WebSocket
        {
            ws.ProcessRequest(context);
            Thread.Sleep(1000);
            logger.Write("Async method ");
            
			var task = DoRespond(context);
			task.Wait(); // wait for async method to complete
			
			// assert something?
        }
        
        return true; // not sure where Boolean return value comes from as it wasn't in original method.
    }
