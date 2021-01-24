        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("button_click event raised");
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
             Response.Write("text_changed event raised : "+ TextBox1.Text);
        }
