    class AuxWindow : Window, ICloseableView
    {
        private bool confirmClose = true;
        public void Close(bool confirmClose)
        {
            try
            {
                this.confirmClose = confirmClose;
                Close();
            }
            finally
            {
                this.confirmClose = true;
            } 
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!this.confirmClose)
            {
                e.Cancel = false;
                return;
            }
            
            // Your code here...
        }
    }
