    public partial class MainWindow : Form
    {
        // ...
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
            base.OnFormClosing(e);
        }
        // ...
    }
