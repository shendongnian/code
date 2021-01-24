    public string TextToReturn;
    
    private void button1_Click(object sender, EventArgs e)
    {
        TextToReturn = text_box.Text; 
        this.DialogResult = DialogResult.OK;
    }
