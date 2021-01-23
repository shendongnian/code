    public partial class SWindow : Window
    {
        public SWindow()
        {
            this.Closing += ShellWindow_Closing;
        }
        private void ShellWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Any running migration task will be aborted.\nAre you sure you want to exit the application ?", "Exit Proventeq Migration Acclerator", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
               e.Cancel = true;
            }
        }
        private void BtnMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
    //designer part
    public partial class SWindow
    {
        //other code
        private void InitializeComponent()
        {
            Button BtnMenuExit = new Button();
            BtnMenuExit.Click += new EventHandler(BtnMenuExit_Click);
            //other styles etc..
        }
        //other code
    }
