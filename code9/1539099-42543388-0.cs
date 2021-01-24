    public string Password
    {
        get { return textBoxPassword.Text; }
        set { }
    }
    public FormPassword()
    {
        InitializeComponent();
    }
    private void buttonOkay_Click(object sender, EventArgs e)
    {
        Close();
    }
