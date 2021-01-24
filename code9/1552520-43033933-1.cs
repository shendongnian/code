    public UserControl2 UserControl2Instance { get; set; }
    private void button1_Click(object sender, EventArgs e)
    {
        if(UserControl2Instance!=null)
        {
            if(UserControl2Instance.CheckBoxValue)
                MessageBox.Show("Checked");
            else
                MessageBox.Show("Unchecked");
        }
    }
