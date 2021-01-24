    public string textToReturn;
    
    private void button1_Click(object sender, EventArgs e)
    {
        textToReturn = text_box.Text; 
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
