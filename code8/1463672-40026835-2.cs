    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size = new Size(800, 600);
            mTextBox = new TextBox();
            mTextBox.Multiline = true;
            mTextBox.Font = new Font("Consolas", 10);
            mTextBox.TextChanged += textbox_TextChanged;
            mTextBox.Dock = DockStyle.Fill;
            mTextBox.Height = 400;
            Splitter splitter = new Splitter();
            splitter.Dock = DockStyle.Bottom;
            mWebBrowser = new WebBrowser();
            mWebBrowser.Dock = DockStyle.Bottom;
            Controls.Add(mTextBox);
            Controls.Add(splitter);
            Controls.Add(mWebBrowser);
            mTextBox.Text = "<html>\r\n<h1>Testing!</h1>\r\n</html>";
        }
        void textbox_TextChanged(object sender, EventArgs e)
        {
            mWebBrowser.DocumentText = mTextBox.Text;
        }
        WebBrowser mWebBrowser;
        TextBox mTextBox;
    }
