    void CreateAndStopProgressBarWhenIsLoaded()
    {
     	var pb = new Controls.ProgressBar.ProgressBar[1];
	
        Thread progressBarThread= new Thread(new ThreadStart(    
        {
                Controls.ProgressBar.ProgressBar progressBar = new Controls.ProgressBar.ProgressBar();
            	pb[0] = progressBar;
                progressBar.IsIndeterminate = true;
                progressBar.LaunchProgressBarInBackground();
                progressBar.ShowDialog();
        }));
        progressBarThread.SetApartmentState(ApartmentState.STA);
        progressBarThread.Start();
        this.Loaded += (sender, e) => {
             pb[0].Dispatcher.Invoke(()=>pb[0].Close());
        };
}
