        public MainWindow()
        {
            InitializeComponent();
            TextBlock tb = new TextBlock();
            var ch = char.ConvertFromUtf32(128076);
            tb.Text = ch.ToString();
            Clipboard.SetText(ch.ToString(), TextDataFormat.UnicodeText);
            tb.Text += Clipboard.GetText(TextDataFormat.UnicodeText);
            this.Content = tb;
        } 
