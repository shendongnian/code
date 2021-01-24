    public partial class someclass : Window, IDisposable // implement IDisposable
    {
        // shortened for brevity
        System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                dlg.Dispose(); // dispose the dialog
        }
        public void Dispose() // IDisposable implementation
        {
            Dispose(true);
            // tell the GC that there's no need for a finalizer call
            GC.SuppressFinalize(this); 
        }
    }
