    public partial class WebBrowserWindow : Window
    {
        public WebBrowserWindow()
        {
            InitializeComponent();
            webBrowser.MenuHandler = new ContextMenuHandler();
            webBrowser.RequestHandler = new RequestHandler();
            MemoryMappedHandler.message.HasMessage += Message_HasMessage;
        }
        
        private void Message_HasMessage(object sender, EventArgs e)
		{
			ExecuteJavaScript(MemoryMappedHandler.message.MyStringWithEvent);
		}
        public void ExecuteJavaScript(string message)
        {
            //webBrowser.GetMainFrame().ExecuteJavaScriptAsync("alert('test')");
            //webBrowser.ExecuteScriptAsync("alert('test');");
        }
    }
