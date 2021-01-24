    try
        {
            double c = Convert.ToDouble(TextBox1.Text);
            c = Add(c, c);
            Button1.Text = c.ToString();
        }
        catch (FormatException)
        {
            Button1.Text = "NaN";
        }
