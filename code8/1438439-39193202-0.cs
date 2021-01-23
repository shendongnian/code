    private void button_showForm2_Click(object sender, EventArgs e)
    {
        this.frm2 = new Form2(this);
        this.frm2.Show();
    }
    
    public void ShowMessage()
    {
        MessageBox.Show("Form2 is hidden. Continue processing next line of code");
    }
