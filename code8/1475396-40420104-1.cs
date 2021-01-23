    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox textBox = sender as TextBox;
    
        int rowNumber = Convert.ToInt32(textBox.CssClass);
        string valueToCompare = GridView1.Rows[rowNumber].Cells[1].Text;
    
        if (textBox.Text == valueToCompare)
        {
            //do stuff
        }
    }
