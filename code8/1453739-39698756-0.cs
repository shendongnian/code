    private void textEdit1_KeyUp(object sender, KeyEventArgs e)
    {
        if (this.textEdit1.Text.Length == 10)
        {
            textEdit2.Text = textEdit1.Text;                
            this.textEdit1.Text = "";
        }
        label2.Text = textEdit1.Text.Length.ToString();
        label1.Text = textEdit2.Text.Length.ToString();
    }
