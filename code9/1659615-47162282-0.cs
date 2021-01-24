    class ViewModel : INotifyPropertyChanged
    {
        private bool isProcessing;
        public bool AddNewProgressBarVisible
        {
            get { return this.isProcessing; }
            // SetProperty here is a PRISM-like helper to set the backing field value
            // and to raise the PropertyChanged event when needed.
            // You might be using something similar.
            private set { this.SetProperty(ref this.isProcessing, value, "AddNewProgressBarVisible");
        }
        private int progressValue;
        public int AddNewProgressBarValue
        {
            get { return this.progressValue; }
            private set { this.SetProperty(ref this.progressValue, value, "AddNewProgressBarValue");
        }
        // This is your command handler
        private void LoadWordDocument(object parameter)
        {
            if (this.isProcessing)
            {
                // don't allow multiple operations at the same time
                return;
            }
         
            // indicate that we're staring an operation:
            // AddNewProgressBarVisible will set isProcessing = true
            this.AddNewProgressBarVisible = true;
            this.AddNewProgressBarValue = 0;
            // Notify the bound button, that it has to re-evaluate its state.
            // Effectively, this disables the button.
            this.LoadWordDocCmd.RaiseCanExecuteChanged();
            // Run the processing on a background thread.
            ThreadPool.QueueUserWorkItem(this.DoLoadWordDocument);
        }
        private void DoLoadWordDocument(object state)
        {
            // Do your document loading here,
            // this method will run on a background thread.
            // ...
            // You can update the progress bar value directly:
            this.AddNewProgressBarValue = 42; // ...estimate the value first
            // When you're done, don't forget to enable the button.
            this.AddNewProgressBarVisible = false;
            this.LoadWordDocCmd.RaiseCanExecuteChanged();
        }
        // this is your command enabler method
        private bool CanLoadWordDoc(object parameter)
        {
            // if we're already loading a document, the command should be disabled
            return this.m_fileSelected && !this.isProcessing;
        }
    }
