    public bool IsFileOpened
    {
        get { return _isFileOpened; }
        set
        {
            _isFileOpened = value;
            UpdateShowButton();
        }
    }
    public bool IsDrive
    {
        get { return _isDrive; }
        set
        {
            _isDrive = value;
            UpdateShowButton();
        }
    }
    public bool IsPrice
    {
        get { return _isPrice; }
        set
        {
            _isPrice = value;
            UpdateShowButton();
        }
    }
    private void UpdateShowButton()
    {
        if (IsPrice && IsDrive && IsFileOpened)
            showButton.Enabled = true;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        drive = CheckIntInput(sender, "not valid");
        if (drive != 0)
        {
            IsDrive = true;
        }
    }
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        price = CheckIntInput(sender, "not valid");
        if (price != 0)
        {
            IsPrice = true;
        }
    }
    private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
        filePath = openFileDialog1.FileName;
        label1.Text = filePath;
        IsFileOpened = true;
    }
