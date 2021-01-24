    private void SomeLongRunningThread()
    {
        Thread.Sleep(3000);
        if (txtResult.InvokeRequired)
        {
            Thread.Sleep(3000);
            txtResult.Invoke((MethodInvoker) delegate { SomeAction });
        }
        else
        {
            Thread.Sleep(3000);
            SomeAction();
        }
        
    }
	
	private void SomeAction(){
        // This lock is not needed as long this method is only called from SomeLongRunningThread()
	    //lock (lockObject)
        //{
			txtResult.Text = DateTime.Now.ToShortTimeString();
		//}
	}
