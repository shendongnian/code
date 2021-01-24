    public sealed partial class CustomKeyBoard : UserControl
    {
        public delegate void BoilerLogHandler(string value);
    
        public event BoilerLogHandler BoilerEventLog;
    
        public CustomKeyBoard()
        {
            this.InitializeComponent();
        }
    
        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (BoilerEventLog != null)
            {
                BoilerEventLog(e.ClickedItem.ToString());
            }
        }
    }
