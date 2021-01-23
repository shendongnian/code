    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        //load from database
        Label1.Text = TextBox1.Text;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        //save to database
        Label1.Text = "Data saved!";
        TextBox1.Text = "";
    }
