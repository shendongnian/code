    private string textForEdit{get;set;}
    public FormEditor(string txt)
    {
        textForEdit = txt;
    }
    private void FormEditor_load(object sender, EventArgs e)
    {
        richTextBox1.Text = textForEdit;
    }
