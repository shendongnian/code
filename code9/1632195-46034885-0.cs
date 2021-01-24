    namespace MMI_WFA
    {
        public partial class MainWindow : Form
        {
            public int Language { get; set; }
            ...
            ...
        }
        public partial class MENU : Form
        {
            public MENU(MainWindow window) { this.window = window; }
    
            private void cbo_Language_SelectedIndexChanged(object sender, EventArgs e)
            {
                window.Language = //
            }
        }
    }
