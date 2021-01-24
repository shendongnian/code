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
            private readonly MainWindow window;
            public MENU(MainWindow window) { this.window = window; }
    
            private void cbo_Language_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.window.Language = //
            }
        }
    }
