    public Form1()
    {
        InitializeComponent();
    }
    public bool x = false;
    public bool j = false;
    private void Preiststop_Click(object sender, EventArgs e)
    {
        j = true;
    }
    private void Preist_Click(object sender, EventArgs e)
    {
        Thread newThread = new Thread(DoPriestWork);
        newThread.Start();
    }
    public void DoPriestWork()
    {
        x = true;
        while (x == true)
        {
            SendKeys.Send(" ");
            Thread.Sleep(5000);
            if (j == true)
                x = false;
        }
    }
