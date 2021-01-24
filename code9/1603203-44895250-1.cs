    private string text = "";
    protected void TextBoxTest_OnTextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        text = txt.Text;
    }
    protected void ButtonExample_OnClick(object sender, EventArgs e)
    {
        //Response.Write(text);
    }
