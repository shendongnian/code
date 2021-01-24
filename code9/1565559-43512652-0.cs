    public static int InstanceCount = 0;
    public Form1()
    {
        InstanceCount++;
        InitializeComponent();
        if (InstanceCount > 1)
        {
            this.button1.Hide();
            this.button2.Hide();
        }
    }
