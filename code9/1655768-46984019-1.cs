        public event EventHandler<ProgressEventArgs> ProgressChanged;
        protected void OnProgressChanged(int progress)
        {
            ProgressChanged?.Invoke(this, new ProgressEventArgs(progress));
        }
