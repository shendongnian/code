    class frmProgress : Windows.Form {
        // Standard stuff
        
        public void DoSomeWorks() {
            Work -= OnWork;
            Work += OnWork;
            Work(this, EventArgs.Empty);//raise the event and do work on other thread   
            ShowDialog();
        }
        private CancellationTokenSource cancelSource;
        private event EventHandler Work = delegate { };
        private async void OnWork(object sender, EventArgs e) {
            Work -= OnWork; //unsubscribe
            cancelSource = new CancellationTokenSource(); //to allow cancellation.
            var _iLikeTheResultOfWork1 = await RunWork1Async(cancelSource.Token);
            if (_iLikeTheResultOfWork1) {
                await RunWork2Async(cancelSource.Token);
            }
            DialogResult = DialogResult.OK; //just an example
        }
        Task<bool> RunWork1Async(CancellationToken cancelToken) {
            // Do a lot of things including update UI
            //if while working cancel called
            if (cancelToken.IsCancellationRequested) {
                return Task.FromResult(false);
            }
			//Do more things
			
            //return true if successful
            return Task.FromResult(true);
        }
        Task<bool> RunWork2Async(CancellationToken cancelToken) {
            // Do a lot of things including update UI
            //if while working cancel called
            if (cancelToken.IsCancellationRequested) {
                return Task.FromResult(false);
            }
			
			//Do more things
            //return true if successful
            return Task.FromResult(true);
        }
    }
	
