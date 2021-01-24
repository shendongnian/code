        private void btDot_Click(object sender, EventArgs e)
        {
            char separator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (sb.ToString().Contains(separator))
                return;
            sb.Append(separator);
            tbValue.Text = sb.ToString();
        }
