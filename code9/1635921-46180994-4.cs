    public partial class Form1 : Form
    {
        // "Closing" event handler
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel |= !closeCriteriaMet; // combine the cancel flag 
        }
    }
