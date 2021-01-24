    private void InitializeComponent()
    {
        // Some code
        this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
        // some code
    }
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        if (this.dateTimePicker2.Value > this.dateTimePicker1.Value)
        {
            this.dateTimePicker2.MaxDate = this.dateTimePicker1.Value;
        }
    }
