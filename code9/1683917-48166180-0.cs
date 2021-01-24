    public Form1()
    {
        InitializeComponent();
        bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        if(!designMode)
        {
            this.comboBox1.Items.AddRange(Enumerable.Range(0, 30).Cast<object>().ToArray());
        }
    }
