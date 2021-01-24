    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        button1.Click += anyButton_Click;
        button2.Click += anyButton_Click;
    }
    private void anyButton_Click(object sender, EventArgs e)
    {
        //do the things
    }
