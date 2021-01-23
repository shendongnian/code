    protected void InputChanged(object sender, EventArgs e)
    {
        TextBox tb = new TextBox();
        tb = sender as TextBox;
        if (tb != null && tb.Text != null)
        {
            try
            {
                var num = Convert.ToInt32(tb.Text);
                tb.Text = num.ToString();
            }
            catch (Exception ex)
            {
                tb.Text = String.Empty;
            }
        }
    }
