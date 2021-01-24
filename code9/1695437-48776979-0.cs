    class frmProgress : Form
    {
        public bool _iLikeTheResultOfWork1 = true;
        // Note: changed to async method and now awaiting the task
        public async void DoSomeWorks()
        {
            await Task.Run(() => RunWork1());
            ShowDialog();
            if (_iLikeTheResultOfWork1)
            {
                await Task.Run(() => RunWork2());
                ShowDialog();
            }
        }
        // Hide window and wait 5 seconds. Note that the main window is active during this 5 seconds.
        // ShowDialog() is called again right after this, so the dialog becomes modal again.
        void RunWork1()
        {
            Hide();
            Task.Delay(5000).Wait();
            // Do a lot of things including update UI
        }
        void RunWork2()
        {
            Hide();
            Task.Delay(5000).Wait();
            // Do a lot of things including update UI
        }
    }
