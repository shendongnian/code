    try
    {
        double c = Convert.ToDouble(TextBox1.Text);
        c = Multiply(c, c);
        Button1.Text = c.ToString();
    }
    catch { Button1.Text = "NaN"; }
