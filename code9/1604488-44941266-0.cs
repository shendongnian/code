    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WebBrowser webbrowser = new WebBrowser();
            webbrowser.Parent = this;
            webbrowser.Dock = DockStyle.Fill;
            webbrowser.Navigate("www.google.com");  
        }
    }
