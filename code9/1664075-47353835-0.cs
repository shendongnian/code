            double num1, num2, product = 0;
            if (tb1.Text.IndexOf(",") != -1)
            {
                tb1.Text = tb1.Text.Replace(",", ".");
            }
            num1 = double.Parse(tb1.Text, System.Globalization.CultureInfo.InvariantCulture);
            if(tb2.Text.IndexOf(",") != -1)
            {
                tb2.Text = tb2.Text.Replace(",", ".");
            }
            num2 = double.Parse(tb2.Text, System.Globalization.CultureInfo.InvariantCulture);
            product = Math.Round(num1 * num2,2);
            tb3.Text = product.ToString();
