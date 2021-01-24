    private void button_Click(object sender, EventArgs e)
    {
        var button = (Button)sender;
        textBox1.Text += button.Tag.ToString();
        counter++;
        again();
    }
    public Form1()
    {
        InitializeComponent();
        button1.Tag = 1;
        button1.Click += button_Click;
        button2.Tag = 2;
        button2.Click += button_Click;
        // and so on for other buttons
    }
