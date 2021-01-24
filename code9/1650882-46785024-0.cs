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
	    lock (lockObject)
        {
			txtResult.Text = DateTime.Now.ToShortTimeString();
		}
	}
