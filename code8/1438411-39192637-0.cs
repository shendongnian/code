    public Form1()
    {
      comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
      InitializeComponent();
      CheckSelction();
    }
    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckSelction();
    }
    void CheckSelction()
    {
      if (comboBox1.SelectedItem != null)
      {
        var item = comboBox1.SelectedItem.ToString();
        button1.Enabled = item == "yes";
      }
      else
        button1.Enabled = false;
    }
