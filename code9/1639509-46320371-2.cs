    double c = 0;
    if (double.TryParse(TextBox1.Text, out c))
    {
        c = Multiply(c, c);
        Button1.Text = c.ToString();
    }
    else
    {
        Button1.Text = "NaN";
    }
