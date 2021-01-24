    private void button1_Click(object sender, EventArgs e)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.Visible = true;
                //add code here to be executed on UI thread before connection check
                Task.Run(new Action(() => 
                {
                    //Task.Run this code on the thread pool instead of your UI thread. So your code is checking connection while progress bar is still rendering
                    ConnectionCheckResult res = new checkInternet().checkInternetAvailable();
                    this.Invoke(new Action(() => 
                    {
                        //this.Invoke executes following delegate on UI thread. All UI changes - like progressBar1.Visible = false; need to be made in UI thread.
                        //add code here to be executed on the UI thread after connection check.
                        progressBar1.Visible = false;
                        if (!string.IsNullOrEmpty(res.Message))
                            MessageBox.Show(res.Message);
    
                    }));
    
                }));
                //add code to be executed on UI thread at the same time as connection check
            }
