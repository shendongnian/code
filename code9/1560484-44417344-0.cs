    public partial class MainForm : Form
    {
        private bool _closeRequested;
        private void OnSourceInstallationCompleted(object sender, EventArgs e)
        {
            if (_closeRequested) { this.Close(); }            
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closeRequested)
            {
                _closeRequested = true;
                e.Cancel = true;
            }
        }
        private void OnExtractionProgressUpdate(object sender, ExtractProgressEventArgs e)
        {
            e.Cancel = _closeRequested;
        }
    }
