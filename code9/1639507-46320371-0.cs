        if(double.TryParse(TextBox1.Text, out double c))
        {
            c = Multiply(c, c);
            Button1.Text = c.ToString();
        }
        else
        {
            Button1.Text = "NaN";
        }
