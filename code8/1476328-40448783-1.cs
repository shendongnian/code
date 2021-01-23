    public Form1()
    {
        InitializeComponent();
        this.Controls.Clear();
        this.AutoSize = false;
        var panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.AutoScroll = true;
        panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.Controls.Add(panel);
        for (int i = 0; i < 20; i++)
        {
            var buttun = new Button();
            buttun.Text = string.Format("Button {0}", i + 1);
            buttun.Dock = DockStyle.Top;
            panel.Controls.Add(buttun);
        }
    }
